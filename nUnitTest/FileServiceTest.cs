using Microsoft.Extensions.Caching.Memory;
using Moq;
using Search.Entities;
using Search.Interfaces;
using Search.Services;
using SearchApp.Interfaces;

namespace nUnitTest
{
    /// <summary>
    /// FileServiceTest
    /// </summary>
    public class FileServiceTest : BaseTest
    {
        private IFileService _fileService;
        private readonly Mock<ICacheService> _cacheServiceMock = new();
        private readonly Mock<ICountService> _countServiceMock = new();

        [OneTimeSetUp]        
        override public void Setup()
        {
            base.Setup(); 
            _fileService = new FileService(_cacheServiceMock.Object, _countServiceMock.Object);
        }

        [Test]
        public void GetNameTest1()
        {
            String fileName = _fileService.GetName(Utils.FILENAME1);
            Assert.That(fileName, Is.EqualTo(Utils.NAME1));
        }

        [Test]
        public void GetNameTest2()
        {
            String fileName = _fileService.GetName(Utils.DIRECTORY);
            Assert.IsEmpty(fileName);
        }

        [Test]
        public async Task GetCountAsyncTest1()
        {
            var counter = await _fileService.GetCountAsync(Utils.WRONG_FILENAME, Utils.WORD);
            AssertCounter(counter, Utils.WRONG_FILENAME, 0);
        }

        [Test]
        public async Task GetCountAsyncTest2()
        {
            // cacheServiceMock            
            _cacheServiceMock.Setup(m => m.IsCached(It.IsAny<string>(), It.IsAny<DateTime>())).Returns(false);
            _countServiceMock.Setup(m => m.Count(It.IsAny<string[]>(), It.IsAny<string>())).Returns(2);

            var counter = await _fileService.GetCountAsync(Utils.FILENAME1, Utils.WORD);
            AssertCounter(counter, Utils.FILENAME1, 2);
        }

        /// <summary>
        /// AssertCounter
        /// </summary>
        /// <param name="counter">Counter</param>
        /// <param name="fileName">Expected filename</param>
        /// <param name="count">Expected count</param>
        private static void AssertCounter(Counter counter, String fileName, int count)
        {
            Assert.Multiple(() =>
            {
                Assert.That(counter.FileName, Is.EqualTo(fileName));
                Assert.That(counter.Count, Is.EqualTo(count));
            });
        }
    }
}