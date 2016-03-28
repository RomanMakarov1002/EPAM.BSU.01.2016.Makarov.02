using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static Euclidean_algoryithm.Logic;

namespace NunitTests
{
    [TestFixture]
    public class LogicClassTests
    {
        [Test]
        public void FindGcdWithEuclid_Test()
        {
            int[][] nums = new int[5][];
            nums[0] = new int[5] {16,8,4,32,64};
            nums[1] = new int[4] {18,-9,27,0};
            nums[2] = new int[3] {-15, -45, -60};
            nums[3] = new int[3] {15,14,13};
            nums[4] = new int[3] {0,0,11};
            int[] results = new int[5] {4, 9, 15, 1, 11};
            TimeSpan time = new TimeSpan();
            for (int i=0; i<nums.Length; i++ )
                Assert.AreEqual(results[i], FindGcdWithEuclid(ref time, nums[i]));
        }

        [TestCase(0, 0, ExpectedException = typeof (ArgumentException))]
        [TestCase(0, 0, 0, 0, 0, 0, ExpectedException = typeof (ArgumentException))]
        [TestCase(5, ExpectedException = typeof (ArgumentException))]
        public int FindGcdWithEuclid_TestExceptions(params int[] arr)
        {
            TimeSpan time = new TimeSpan();
            return (FindGcdWithEuclid(ref time,arr));
        }

        [Test]
        public void FindGcdWithStein_Test()
        {
            int[][] nums = new int[5][];
            nums[0] = new int[5] { 16, 8, 4, 32, 64 };
            nums[1] = new int[4] { 18, 9, 27, 0 };
            nums[2] = new int[3] { 15, 45, 60 };
            nums[3] = new int[3] { 15, 14, 13 };
            nums[4] = new int[3] { 0, 0, 11 };
            int[] results = new int[5] { 4, 9, 15, 1, 11 };
            TimeSpan time = new TimeSpan();
            for (int i = 0; i < nums.Length; i++)
                Assert.AreEqual(results[i], FindGcdWithStein(ref time, nums[i]) );
        }
    }
}
