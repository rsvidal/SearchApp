using Search.Interfaces;
using Search.Entities;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Cryptography;

namespace Search.Services
{
    public class CacheService : ICacheService
    {
        public Dictionary<string, FileContent> files = new Dictionary<string, FileContent>();

        private readonly string[] SEPARATORS = { " ", "\r", "\n", ".", ",", @"/", @"\", @"'", "\"" };

        /// <summary>
        /// IsCached
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileDate"></param>
        /// <returns>TRUE if file is cached, FALSE otherwise</returns>        
        public bool IsCached(string fileName, DateTime fileDate) => files.ContainsKey(fileName) && (files[fileName]?.LastDate ?? DateTime.MinValue) >= fileDate;

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public String[] Get(string fileName) => files.GetValueOrDefault(fileName)?.Words ?? Array.Empty<string>();

        /// <summary>
        /// Set. Add or update file in cache
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileDate"></param>
        /// <param name="content"></param>
        public void Set(string fileName, DateTime fileDate, string content)
        {
            // string -> string[]
            string[] words = content != null ? content.Split(SEPARATORS, StringSplitOptions.RemoveEmptyEntries) : Array.Empty<string>();

            FileContent? fileContent = files.GetValueOrDefault(fileName);
            if (fileContent == null)
            {                
                files.Add(fileName, new FileContent(fileDate, words));
                return;
            }

            if (fileContent.LastDate.CompareTo(fileDate) < 0)
                fileContent.Set(fileDate, words);
        }

        /// <summary>
        /// Clean filenames (deleted files)
        /// </summary>
        /// <param name="fileNames"></param>
        public void Clean(IEnumerable<string> fileNames)
        {            
            foreach (string fileName in files.Keys)
                if (!fileNames.Contains(fileName))
                    files.Remove(fileName);
        }
    }
}