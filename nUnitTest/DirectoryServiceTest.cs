using NUnit.Framework.Constraints;

namespace nUnitTest
{
    /// <summary>
    /// DirectoryServiceTest
    /// </summary>
    public class DirectoryServiceTest : BaseTest
    {
        [Test]
        public void ExistsTest1() => Assert.True(Directory.Exists(Utils.DIRECTORY));

        [Test]
        public void ExistsTest2() => Assert.False(Directory.Exists(Utils.WRONG_DIRECTORY));

        [Test]
        public void GetTxtFilesTest1()
        {
            var files = _directoryService.GetTxtFiles(Utils.DIRECTORY);
            Assert.That(files.Count(), Is.EqualTo(3)); // 1.txt, 2.txt y 3.txt. Note: image.jpg is skipped
        }

        [Test]
        public void GetTxtFilesTest2()
        {
            var files = _directoryService.GetTxtFiles(Utils.WRONG_DIRECTORY);
            Assert.That(files.Count(), Is.EqualTo(0)); // Directory doesn't exist
        }
    }
}