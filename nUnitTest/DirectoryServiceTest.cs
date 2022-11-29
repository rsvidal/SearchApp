using NUnit.Framework.Constraints;

namespace nUnitTest
{
    /// <summary>
    /// DirectoryServiceTest
    /// </summary>
    public class DirectoryServiceTest : BaseTest
    {
        [Test]
        public void Exists_Directory_Returns_True() => Assert.True(Directory.Exists(Utils.DIRECTORY));

        [Test]
        public void Not_Exists_Wrong_Directory_Returns_False() => Assert.False(Directory.Exists(Utils.WRONG_DIRECTORY));

        [Test]
        public void Get_Files_In_Directory_Returns_Three()
        {
            var files = _directoryService.GetTxtFiles(Utils.DIRECTORY);
            Assert.That(files.Count(), Is.EqualTo(3)); // 1.txt, 2.txt y 3.txt. Note: image.jpg is skipped
        }

        [Test]
        public void Get_files_In_Wrong_Directory_Returns_Zero()
        {
            var files = _directoryService.GetTxtFiles(Utils.WRONG_DIRECTORY);
            Assert.That(files.Count(), Is.EqualTo(0)); // Directory doesn't exist
        }
    }
}