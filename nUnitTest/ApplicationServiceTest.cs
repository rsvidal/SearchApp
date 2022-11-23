using nUnitTest.Interfaces;
using System.Reflection;
using Search;
using Search.Interfaces;
using Moq;

namespace nUnitTest
{
    public class ApplicationServiceTest
    { 
        private Application _application;
        private Mock<IDirectoryService> _directoryServiceMock = new();
        private Mock<IFileService> _fileServiceMock = new();
        private Mock<ITopService> _topServiceMock = new();

        readonly object[] parameters = { Utils.DIRECTORY };

        [OneTimeSetUp]
        public void Setup() => _application = new Application(_directoryServiceMock.Object, _fileServiceMock.Object, _topServiceMock.Object);

        [Test]
        public void ReadDirectoryTest1()
        {
            // directoryServiceMock            
            _directoryServiceMock.Setup(m => m.GetTxtFiles(It.IsAny<string>()))
                .Returns(new List<string>
                    { Utils.FILENAME1, Utils.FILENAME2 });

            IEnumerable<string> result = (IEnumerable<string>)Invoke(_application, "ReadDirectory", parameters);
            Assert.That(result, Is.Not.Null); 
            Assert.That(result.Count(), Is.EqualTo(2));
        }

        private static Object? Invoke(object o, string methodName, params object[] args)
        {
            var method = o.GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return method?.Invoke(o, args);
        }
    }
}