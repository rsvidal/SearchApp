using Search.Interfaces;
using Search.Entities;

namespace Search.Services
{
    public class FileService : IFileService
    {
        private readonly ICacheService _cacheService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cacheService"></param>
        public FileService(ICacheService cacheService) => _cacheService = cacheService;

        /// <summary>
        /// GetName (and extension file)
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Name (and extension file)</returns>
        public string GetName(string fileName) => Path.GetFileName(fileName);

        /// <summary>
        /// GetCountAsync
        /// </summary>
        /// <remarks>Count words into the file</remarks>
        /// <param name="fileName"></param>
        /// <param name="word"></param>
        /// <returns>FileName and count</returns>
        public async Task<Counter> GetCountAsync(string fileName, string word)
        {
            // DEBUG Console.WriteLine($"{fileName} file task started!");
            var counter = new Counter(fileName, 0);
            if (!File.Exists(fileName))
                return counter;

            DateTime lastWriteTime = File.GetLastWriteTime(fileName);

            // If file isn't cached, read file and set it in cache
            if (!_cacheService.IsCached(fileName, lastWriteTime))
            {
                // DEBUG Console.WriteLine($"Reading {fileName} from fileSystem because it is not cached ...");
                var content = await File.ReadAllTextAsync(fileName);
                _cacheService.Set(fileName, lastWriteTime, content);                
            }

            counter.Count = _cacheService.Count(fileName, word);            
            // DEBUG Console.WriteLine($"{fileName} file. Task finished!");
            return counter;
        }

        /// <summary>
        /// Clean memory cache
        /// </summary>
        /// <param name="fileNames"></param>
        public void Clean(IEnumerable<string> fileNames) => _cacheService.Clean(fileNames);
    }
}