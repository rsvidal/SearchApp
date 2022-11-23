namespace Search.Entities
{
    public class Counter
    {
        public string FileName { get; set; }

        public int Count { get; set; } = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="count"></param>
        public Counter(string fileName, int count) => (FileName, Count) = (fileName, count);
    }
}