namespace Search.Interfaces
{
    public interface ICacheService
    {
        bool IsCached(string fileName, DateTime fileDate);

        string[] Get(string fileName);

        void Set(string fileName, DateTime fileDate, string content);

        void Clean(IEnumerable<string> filenames);
    }
}
