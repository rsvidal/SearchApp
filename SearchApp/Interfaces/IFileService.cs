using Search.Entities;

namespace Search.Interfaces
{
    public interface IFileService
    {
        string GetName(string fileName);

        Task<Counter> GetCountAsync(string fileName, string word);

        void Clean(IEnumerable<string> filenames);
    }
}