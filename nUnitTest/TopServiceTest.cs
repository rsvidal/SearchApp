using Moq;
using nUnitTest.Interfaces;
using Search.Entities;
using Search.Interfaces;
using Search.Services;

namespace nUnitTest
{
    /// <summary>
    /// TopServiceTest
    /// </summary>
    /// <remarks>This test needs only Setup (No TearDown)</remarks>
    public class TopServiceTest: ISetupTest
    {
        private ITopService _topService;
        private Mock<IFileService> _fileServiceMock = new();

        [OneTimeSetUp]        
        public void Setup() => _topService = new TopService(_fileServiceMock.Object); 

        [Test]
        public async Task GetTopAsyncTest1()
        {
            // fileServiceMock            
            _fileServiceMock.Setup(m => m.GetCountAsync(Utils.FILENAME1, It.IsAny<string>())).Returns(Task.FromResult(new Counter(Utils.FILENAME1, 2)));
            _fileServiceMock.Setup(m => m.GetName(Utils.FILENAME1)).Returns(Utils.NAME1);
            _fileServiceMock.Setup(m => m.GetCountAsync(Utils.FILENAME2, It.IsAny<string>())).Returns(Task.FromResult(new Counter(Utils.FILENAME2, 0)));
            _fileServiceMock.Setup(m => m.GetName(Utils.FILENAME2)).Returns(Utils.NAME2);
            
            Dictionary<string, int> expected = new Dictionary<string, int> { { Utils.NAME1, 2 } }; // Expected result
            var top = await _topService.GetTopAsync(new[] { Utils.FILENAME1, Utils.FILENAME2 }, Utils.WORD);            
            Assert.That(top, Is.EqualTo(expected));
        }

        [Test]
        public async Task GetTopAsyncTest2()
        {
            // fileServiceMock            
            _fileServiceMock.Setup(m => m.GetCountAsync(Utils.FILENAME1, It.IsAny<string>())).Returns(Task.FromResult(new Counter(Utils.FILENAME1, 2)));
            _fileServiceMock.Setup(m => m.GetName(Utils.FILENAME1)).Returns(Utils.NAME1);
            _fileServiceMock.Setup(m => m.GetCountAsync(Utils.WRONG_FILENAME, It.IsAny<string>())).Throws(new Exception());

            Dictionary<string, int> expected = new Dictionary<string, int> { { Utils.NAME1, 2 } }; // Expected result
            var top = await _topService.GetTopAsync(new[] { Utils.FILENAME1, Utils.WRONG_FILENAME }, Utils.WORD);
            Assert.That(top, Is.EqualTo(expected));
        }
    }
}