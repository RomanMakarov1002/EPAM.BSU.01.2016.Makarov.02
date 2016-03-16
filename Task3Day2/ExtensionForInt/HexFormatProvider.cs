using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionForInt
{
    public class HexFormatProvider:IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            return formatType == typeof (ICustomFormatter) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (format.ToUpperInvariant() == "H")
            {
                if (arg is int)
                    return ToHex((int)arg);
                else
                    throw new ArgumentException("H format is available only for integers");

            }           
            return HandleOtherFormats(format, arg);            
        }

        
        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }


        private string ToHex(int num)
        {
            int rest = Math.Abs(num);
            int bit;
            StringBuilder sb = new StringBuilder();
            char[] hex = new char[16] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
            while (rest != 0)
            {
                bit = rest - (rest / 16) * 16;
                sb.Append(hex[bit]);
                rest = rest / 16;
            }
            if (num == 0)
                sb.Append('0');
            sb.Append("x0");
            if (num < 0)
                sb.Append('-');
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
