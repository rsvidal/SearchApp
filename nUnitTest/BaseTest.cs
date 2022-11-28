using nUnitTest.Interfaces;
using Search.Interfaces;
using Search.Services;

namespace nUnitTest
{
    /// <summary>
    /// BaseTest
    /// </summary>
    /// <remarks>This test need Setup and TearDown. DirectoryServiceTest and FileServiceTest inherit from BaseTest</remarks>
    abstract public class BaseTest: ISetupTest, ITearDownTest
    {
        protected IDirectoryService _directoryService;

        [OneTimeSetUp]
        virtual public void Setup()
        {
            _directoryService = new DirectoryService();
            Directory.CreateDirectory(Utils.DIRECTORY);
            CreateFile(Utils.FILENAME1);
            CreateFile(Utils.FILENAME2);
            CreateFile(Utils.FILENAME3);
            CreateFile(Utils.FILENAME4);
        }

        protected static void CreateFile(String fileName)
        {
            var fs = File.Create(fileName);
            fs.Close();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            // Remove directory and subdirectories/files
            Directory.Delete(Utils.DIRECTORY, true);
        }
    }
}