using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Euclidean_algoryithm
{
    public class Logic
    {
        public static int FindGcdWithEuclid(ref TimeSpan time, int value1, int value2)
        {
            if (value1 == 0 && value2 == 0)
                throw new  ArgumentException("At least one number must be non-zero");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var gcd = CalculateForEuclid(value1, value2);
            sw.Stop();
            time = sw.Elapsed;
            return Math.Abs(gcd);
        }

        public static int FindGcdWithEuclid(ref TimeSpan time, int value1, int value2, int value3)
        {
            if (value1 == 0 && value2 == 0 && value3 == 0)
                throw new ArgumentException("At least one number must be non-zero");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var gcd = CalculateForEuclid(value1, value2, value3);
            sw.Stop();
            time = sw.Elapsed;
            return Math.Abs(gcd);
        }

        public static int FindGcdWithEuclid(ref TimeSpan time, params int[] values)
        {
           if(values == null || values.Length <2)
                throw  new  ArgumentException("Need at least 2 numbers to find GCD");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var gcd = CalculateForEuclid(values);
            sw.Stop();
            time = sw.Elapsed;
            return Math.Abs(gcd);
        }

        public static uint FindGcdWithStein(ref TimeSpan time, uint value1, uint value2)
        {
            if (value1 == 0 && value2 == 0)
                throw new ArgumentException("At least one number must be non-zero");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            uint gcd = CalculateForStein(value1, value2);
            sw.Stop();
            time = sw.Elapsed;
            return gcd;
        }


        public static uint FindGcdWithStein(ref TimeSpan time, params uint[] values)
        {
            if (values== null || values.Length<2)
                throw new ArgumentException("Need at least 2 numbers to find GCD");
            bool allZero = true;
            for (int i=0; i<values.Length; i++)
                if (values[i] != 0)
                    allZero = false;
            if (allZero)
                throw new ArgumentException("At least one number must be non - zero");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 1; i < values.Length; i++)
                values[0]=CalculateForStein(values[0], values[i]);
            sw.Stop();
            time = sw.Elapsed;
            return values[0];
        }

        private static uint CalculateForStein(uint value1, uint value2)
        {
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


        private static int CalculateForEuclid(params int[] values)
        {
            bool allZero = true;
            if (values[0] != 0)
                allZero = false;
            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] != 0)
                    allZero = false;
                while (values[i] != 0)
                {
                    var t = values[i];
                    values[i] = values[0] % values[i];
                    values[0] = t;
                }
            }
            if (allZero)
                throw new ArgumentException("At least one number must be non-zero");
            return values[0];
        }
    }
}
