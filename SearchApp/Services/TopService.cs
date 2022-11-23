using Search.Entities;
using Search.Interfaces;
using System.Linq;

namespace Search.Services
{
    public class TopService: ITopService
    {
        private IFileService _fileService;
        private const int MAX = 10;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileService"></param>
        public TopService(IFileService fileService) => _fileService = fileService;

        /// <summary>
        /// GetTopAsync
        /// </summary>
        /// <param name="fileNames"></param>
        /// <param name="word"></param>
        /// <returns>Top files</returns>
        public async Task<Dictionary<string, int>> GetTopAsync(IEnumerable<string> fileNames, string word)
        {
            var tasks = new List<Task<Counter>>();
            foreach (String fileName in fileNames)
            {
                try
                {
                    tasks.Add(_fileService.GetCountAsync(fileName, word));
                }
                catch (Exception ex) { Console.WriteLine($"{fileName} file skipped! Message error: {ex.Message}"); }
            }

            // Waiting for tasks to finish
            await Task.WhenAll(tasks.ToArray());

            var top = new Dictionary<string, int>();
            foreach (Task<Counter> task in tasks)
                if (task.Result.Count > 0)
                    top.Add(_fileService.GetName(task.Result.FileName), task.Result.Count);

            /* Using LINQ 
            foreach (var task in 
                from Task<ContentFile> task in tasks
                where task.Result.Count > 0
                select task)
            {
                top.Add(_fileService.GetName(task.Result.FileName), task.Result.Count);
            } */

            return top.OrderByDescending(x => x.Value).Take(MAX)
                .OrderBy(x => x.Key) // Order by name. If you remove this sentence, this method returns the Top10 list sorted by 'number of words' in each file
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}