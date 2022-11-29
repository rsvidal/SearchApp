using Moq;
using Search;
using Search.Interfaces;

namespace nUnitTest
{
    /// <summary>
    /// AplicationServiceTest
    /// </summary>
    public class ApplicationServiceTest
    { 
        private Application _application;
        private readonly Mock<IDirectoryService> _directoryServiceMock = new();
        private readonly Mock<IFileService> _fileServiceMock = new();
        private readonly Mock<ITopService> _topServiceMock = new();

        readonly object[] parameters = { Utils.DIRECTORY };

        [OneTimeSetUp]
        public void Setup() => _application = new Application(_directoryServiceMock.Object, _fileServiceMock.Object, _topServiceMock.Object);

        [Test]
        public void Read_Directory_Returns_Two_Files()
        {
            // directoryServiceMock            
            _directoryServiceMock.Setup(m => m.GetTxtFiles(It.IsAny<string>())).Returns(new List<string> { Utils.FILENAME1, Utils.FILENAME2 });

            IEnumerable<string>? result = Invoke(_application, Utils.READ_DIRECTORY_METHOD, parameters) as IEnumerable<string>;
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Count(), Is.EqualTo(2));
            });
        }

        private static Object? Invoke(object obj, string methodName, params object[] args)
        {
            var method = obj.GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return method?.Invoke(obj, args);
        }
    }
}