using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Euclidean_algoryithm
{
    public static class Logic
    {
        public static int FindGcdWithEuclid(ref TimeSpan time, int value1, int value2)
        {
            return Find(Calculate, ref time, value1, value2);
        }

        public static int FindGcdWithEuclid(int value1, int value2)
        {
            return Find(Calculate, value1, value2);
        }

        public static int FindGcdWithEuclid(ref TimeSpan time, int value1, int value2, int value3)
        {
            return Find(Calculate, ref time, value1, value2, value3);
        }

        public static int FindGcdWithEuclid(int value1, int value2, int value3)
        {
            return Find(Calculate, value1, value2, value3);
        }

        public static int FindGcdWithEuclid(ref TimeSpan time, params int[] values)
        {
            return Find(Calculate, ref time, values);
        }

        public static int FindGcdWithEuclid(params int[] values)
        {
            return Find(Calculate, values);
        }



        public static int FindGcdWithStein(ref TimeSpan time, int value1, int value2)
        {
            return Find(CalculateForStein, ref time, value1, value2);
        }

        public static int FindGcdWithStein(int value1, int value2)
        {
            return Find(CalculateForStein, value1, value2);
        }

        public static int FindGcdWithStein(ref TimeSpan time, int value1, int value2, int value3)
        {
            return Find(CalculateForStein, ref time, value1, value2, value3);
        }

        public static int FindGcdWithStein(int value1, int value2, int value3)
        {
            return Find(CalculateForStein, value1, value2, value3);
        }

        public static int FindGcdWithStein(ref TimeSpan time, params int[] values)
        {
            return Find(CalculateForStein, ref time, values);
        }

        public static int FindGcdWithStein(params int[] values)
        {
            return Find(CalculateForStein, values);
        }



        private static int Find(Func<int, int, int> del, int value1, int value2)
        {
            if (value1==0 && value2==0)
                throw new ArgumentException("At least one number must be non-zero");
            return del(value1,value2);
        }

        private static int Find(Func<int, int, int> del, int value1, int value2, int value3)
        {
            if (value1==0 && value2 == 0 && value3 == 0)
                throw new ArgumentException("At least one number must be non-zero");
            return del(value1,(del(value2, value3)));
        }

        private static int Find(Func<int, int, int> del, ref TimeSpan time, int value1, int value2)
        {
            if (value1 == 0 && value2 == 0)
                throw new ArgumentException("At least one number must be non-zero");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = del(value1, value2);
            sw.Stop();
            time = sw.Elapsed;
            return result;
        }

        private static int Find(Func<int, int, int> del, ref TimeSpan time, int value1, int value2, int value3)
        {
            if (value1 == 0 && value2 == 0 && value3 == 0)
                throw new ArgumentException("At least one number must be non-zero");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = del(value1, del(value2, value3));
            sw.Stop();
            time = sw.Elapsed;
            return result;
        }

        private static int Find(Func<int, int, int> del, params int[] values)
        {
            if (values == null || values.Length < 2)
                throw new ArgumentException("Need at least 2 numbers to find GCD");
            var result = values[0];
            for (int i = 1; i < values.Length; i++)
                result = del(result, values[i]);
            if (result == 0)
                throw new ArgumentException("At least one number must be non-zero");
            return result;
        }

        private static int Find(Func<int, int, int> del, ref TimeSpan time, params int[] values)
        {
            if (values == null || values.Length < 2)
                throw new ArgumentException("Need at least 2 numbers to find GCD");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = values[0];
            for (int i = 1; i < values.Length; i++)
                result = del(result, values[i]);
            sw.Stop();
            time = sw.Elapsed;
            if (result == 0)
                throw new ArgumentException("At least one number must be non-zero");
            return result;
        }
               


        private static int CalculateForStein(int value1, int value2)
        {
            if (value1 < 0)
                value1 *= -1;
            if (value2 < 0)
                value2 *= -1;
            if (value1 == 0) return value2;
            if (value2 == 0) return value1;
            if (value1 == value2) return value1;

            bool value1IsEven = (value1 & 1u) == 0;
            bool value2IsEven = (value2 & 1u) == 0;

            if (value1IsEven && value2IsEven)
            {
                return CalculateForStein(value1 >> 1, value2 >> 1) << 1;
            }
            else if (value1IsEven && !value2IsEven)
            {
                return CalculateForStein(value1 >> 1, value2);
            }
            else if (value2IsEven)
            {
                return CalculateForStein(value1, value2 >> 1);
            }
            else if (value1 > value2)
            {
                return CalculateForStein((value1 - value2) >> 1, value2);
            }
            else
            {
                return CalculateForStein(value1, (value2 - value1) >> 1);
            }
        }


        private static int Calculate(int left, int right)
        {
            while (right != 0)
            {
                var t = right;
                right = left % right;
                left = t;
            }
            return Math.Abs(left);
        }      
    }
}
