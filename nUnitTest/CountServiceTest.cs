using Search.Services;
using SearchApp.Interfaces;
using SearchApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nUnitTest
{
    internal class CountServiceTest
    {
        private ICountService _countService;

        [OneTimeSetUp]
        public void Setup() => _countService = new CountService();

        [Test]
        public void Count_Words_In_Array_Returns_Two()
        {
            int count = _countService.Count(Utils.WORDS, Utils.WORD);
            Assert.That(count, Is.EqualTo(2));
        }
    }
}
