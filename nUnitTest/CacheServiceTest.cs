using nUnitTest.Interfaces;
using Search.Interfaces;
using Search.Services;

namespace nUnitTest
{
    public class CacheServiceTest : ISetupTest
    {
        private ICacheService _cacheService;

        [OneTimeSetUp]
        public void Setup() {            
            _cacheService = new CacheService();
            _cacheService.Set(Utils.FILENAME1, DateTime.Now.AddHours(-1), String.Join(" ", Utils.CONTENT1));
            _cacheService.Set(Utils.FILENAME2, DateTime.Now.AddHours(-1), String.Join(" ", Utils.CONTENT2));
        }

        [Test]
        public void IsCachedTest1()
        {
            bool isCached = _cacheService.IsCached(Utils.FILENAME1, DateTime.Now.AddHours(-2));
            Assert.That(isCached, Is.True);
        }

        [Test]
        public void IsCachedTest2()
        {
            bool isCached1 = _cacheService.IsCached(Utils.FILENAME1, DateTime.Now);
            bool isCached2 = _cacheService.IsCached(Utils.WRONG_FILENAME, DateTime.Now);
            Assert.That(isCached1 && isCached2, Is.False);
        }
    }
}
