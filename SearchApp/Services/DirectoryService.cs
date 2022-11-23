using Search.Interfaces;
using System.IO;

namespace Search.Services
{
    public class DirectoryService : IDirectoryService
    {
        private const string TXTPATTERN = "*.txt";

        /// <summary>
        /// Exists
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns>TRUE is the directory exists, FALSE in otherwise</returns>
        public bool Exists(string directoryName) => Directory.Exists(directoryName);

        /// <summary>
        /// GetTxtFiles
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns>Text files list</returns>
        public IEnumerable<string> GetTxtFiles(string directoryName)
        {
            try
            {
                return Exists(directoryName) ? Directory.GetFiles(directoryName, TXTPATTERN) : new List<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading files in directory {directoryName}. Message error: {ex.Message}");
                return new List<string>();
            }            
        }
    }
}