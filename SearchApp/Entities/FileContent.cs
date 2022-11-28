namespace Search.Entities
{
    public class FileContent
    {        
        public DateTime LastDate  { get; private set; }

        public string[] Words { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lastDate"></param>
        /// <param name="words"></param>
        public FileContent(DateTime lastDate, string[] words) => (LastDate, Words) = (lastDate, words);

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="lastDate"></param>
        /// <param name="words"></param>
        public void Set(DateTime lastDate, string[] words) => (LastDate, Words) = (lastDate, words);

        /// <summary>
        /// Count words
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int Count(string word) => Words.Where(e => e == word).ToList().Count;
    }
}