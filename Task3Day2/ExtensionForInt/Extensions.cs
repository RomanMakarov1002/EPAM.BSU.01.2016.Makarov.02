using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExtensionForInt
{
    public static class Extensions
    {
        public static string IntFormatToHex(this int num)
        {
            int rest=num;
            int bit;
            StringBuilder sb = new StringBuilder();
            
            if (num == 0)
                sb.Append('0');
            if (num > 0)
            {
                char[] arr = new char[16] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
                while (rest != 0)
                {
                    bit = rest - (rest/16)*16;
                    sb.Append(arr[bit]);
                    rest = rest/16;
                }
            }
            if (num < 0)
            {                
                rest = Math.Abs(num);
                char[] arr2 = new char[16] { 'F', 'E', 'D', 'C', 'B', 'A', '9', '8', '7', '6', '5', '4', '3', '2', '1', '0' };
                while (rest!=0)
                {
                    bit = rest - (rest / 16) * 16;
                    if (sb.Length==0)
                        sb.Append(arr2[bit-1]);
                    else
                        sb.Append(arr2[bit]);
                    rest = rest / 16;
                }
                for (int i = sb.Length; i < 8; i++)
                    sb.Append('F');
            }
            return Reverse(sb.ToString());
        }
        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
