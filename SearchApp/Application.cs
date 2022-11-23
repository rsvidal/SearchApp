using Search.Interfaces;
using Search.Services;

namespace Search
{
    public class Application 
    {
        // NOTE: These services has been registered in the service container and they are injected in the contructor method: Contructor injection        
        private IDirectoryService _directoryService;
        private IFileService _fileService;
        private ITopService _topService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="directoryService"></param>
        /// <param name="topService"></param>
        public Application(IDirectoryService directoryService, IFileService fileService, ITopService topService) => (_directoryService, _fileService, _topService) = (directoryService, fileService, topService);

        /// <summary>
        /// Run application
        /// </summary>
        /// <param name="path"></param>
        public void Run(String path) {

            // Directory path
            if (!_directoryService.Exists(path))
            {
                Console.WriteLine($"{path} directory not found!");
                return;
            }

            // Read directory
            if (!ReadDirectory(path).Any())
                return;

            // User console
            while (true)
            {
                Console.Write("\nsearch> ");
                string? word = Console.ReadLine();
                if (String.IsNullOrEmpty(word))
                    return;

                // Read directory
                IEnumerable<String> fileNames = ReadDirectory(path);
                if (!fileNames.Any())
                    return;

                // Clean cache (deleted files)
                _fileService.Clean(fileNames);

                // 'Result' blocks the calling thread until the asynchronous operation has been completed (Equivalent to calling a 'Wait' method)
                var top = _topService.GetTopAsync(fileNames, word).Result;
                if (!top.Any())
                {
                    Console.WriteLine($"{word} no matches found!");
                    continue;
                }

                foreach (var entry in top)
                    Console.WriteLine($"{entry.Key} : {entry.Value} ocurrences");
            }
        }

        /// <summary>
        /// Read directory
        /// </summary>
        /// <remarks>Read text files (*.txt) in path</remarks>
        /// <param name="path"></param>
        /// <returns>FileNames</returns>
        private IEnumerable<string> ReadDirectory(string path)
        {
            IEnumerable<string> fileNames = _directoryService.GetTxtFiles(path);

            Console.WriteLine($"{fileNames.Count()} files read in directory {path}");
            if (!fileNames.Any())
                Console.WriteLine("No *.txt files found!");

            return fileNames;
        }
    }
}