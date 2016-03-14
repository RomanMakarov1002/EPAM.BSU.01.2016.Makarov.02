using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static ExtensionForInt.Extensions;

namespace NUnitTests
{
    [TestFixture]
    public class ExtensionForIntClassTests
    {
        [Test]
        public void IntFormatToHex_Test()
        {
            int[] testNums = new int[10] { 32767, 6400, 152, 10, 1, 0, -1, -152, -32767, 16 };
            string[] expectedResults = new string[10] {"7FFF", "1900", "98", "A", "1", "0", "FFFFFFFF", "FFFFFF68", "FFFF8001", "10"};
            for (int i=0; i<testNums.Length; i++)
                Assert.AreEqual(expectedResults[i], testNums[i].IntFormatToHex());
        }
    }
}
