namespace Search.Interfaces
{
    public interface IDirectoryService
    {
        bool Exists(string directoryName);

        IEnumerable<string> GetTxtFiles(string directoryName);
    }
}