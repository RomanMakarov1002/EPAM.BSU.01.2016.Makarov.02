using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustFormatProvider
{
    public class CustomFormatProvider:IFormatProvider, ICustomFormatter
    {

        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            string result="";
            if (format.ToUpperInvariant() == "N")
            {
                result = "Customer: " + arg.ToString()+".";
            }
            if (format.ToUpperInvariant() =="R")
            {
                result = "Revenue: " + string.Format("{0:C}",arg)+".";
            }
            if (format.ToUpperInvariant() == "P")
                result = "Phone: " + arg.ToString()+".";
            return result;           
        }
        
    }
}
