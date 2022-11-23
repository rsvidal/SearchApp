namespace Search.Interfaces
{
    public interface ICacheService
    {
        bool IsCached(string fileName, DateTime fileDate);

        void Set(string fileName, DateTime fileDate, string content);

        int Count(string fileName, string word);

        void Clean(IEnumerable<string> filenames);
    }
}
