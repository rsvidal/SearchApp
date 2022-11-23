namespace Search.Interfaces
{
    public interface ITopService
    {
        Task<Dictionary<string, int>> GetTopAsync(IEnumerable<string> fileNames, string word);
    }
}