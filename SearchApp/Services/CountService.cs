using SearchApp.Interfaces;

namespace SearchApp.Services
{
    public class CountService: ICountService
    {
        /// <summary>
        /// Count 
        /// </summary>
        /// <param name="words"></param>
        /// <param name="word"></param>
        /// <returns>Count of word</returns>
        public int Count(string[] words, string word) => words.Where(e => e == word).ToList().Count;
    }
}
