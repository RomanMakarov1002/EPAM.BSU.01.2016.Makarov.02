using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustFormatProvider;

namespace Task4
{
    public class Customer: IFormattable
    {
        public string Name { get; }
        public string ContactPhone { get; }
        public decimal Revenue { get; }

        public Customer(string name, string phone, decimal revenue)
        {
            this.Name = name;
            this.ContactPhone = phone;
            this.Revenue = revenue;
        }

        public override string ToString()
        {
            return ToString("N", CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format)||format.ToUpperInvariant()=="G")
                format = "N";
            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }
            string ft = format.ToUpperInvariant();
            StringBuilder sb = new StringBuilder();
            if (formatProvider is CultureInfo)
            {
                if (ft.Contains('N'))
                {                   
                    sb.Append(Name.ToString(formatProvider));
                    sb.Append(' ');
                }
                if (ft.Contains('R'))
                {
                    sb.Append(Revenue.ToString("C0",formatProvider));
                    sb.Append(' ');
                }
                if (ft.Contains('P'))
                {
                    sb.Append(ContactPhone.ToString(formatProvider));
                    sb.Append(' ');
                }
            }
            else
            {
                if (ft.Contains('N'))
                {
                    sb.AppendFormat(formatProvider, "{0:N}", Name);
                    sb.Append(' ');
                }
                if (ft.Contains('R'))
                {
                    sb.AppendFormat(formatProvider, "{0:R}", Revenue);
                    sb.Append(' ');
                }
                if (ft.Contains('P'))
                {
                    sb.AppendFormat(formatProvider, "{0:P}", ContactPhone);
                    sb.Append(' ');
                }
            }         
            return sb.ToString();
        }

       
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }
        
    }    
}
