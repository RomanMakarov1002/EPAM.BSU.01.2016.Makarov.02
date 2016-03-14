using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Customer
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
            return ToString("123");
        }

        public string ToString(string format)
        {

        switch (format)
            {
                case "123":
                    return string.Format("Customer record: {0}, {1}, {2}", Name, Revenue.ToString("N0"), ContactPhone);
                case "12":
                    return string.Format("Customer record: {0}, {1}", Name, Revenue.ToString("N0"));
                case "13":
                    return string.Format("Customer record: {0}, {1}", Name, ContactPhone);
                case "23":
                    return string.Format("Customer record: {0}, {1}", Revenue.ToString("N0"), ContactPhone);
                case "1":
                    return string.Format("Customer record: {0}", Name);
                case "2":
                    return string.Format("Customer record: {0}", Revenue.ToString("N0"));
                case "3":
                    return string.Format("Customer record: {0}", ContactPhone);               

                default:
                    throw new ArgumentException(string.Format("'{0}' is an invalid format string", format));
            }
        }
    }

    public static class OtherClass
    {
        public static string NameFormatter(this Customer customer, int length)
        {
            return string.Format("Customer record: {0}, {1}, {2}", customer.Name.Substring(0,length), customer.Revenue.ToString("N0"), customer.ContactPhone );           
        }

        public static string PhoneFormatter(this Customer customer)
        {
            return string.Format("Customer record: {0}, {1}, {2}", customer.Name, customer.Revenue.ToString("N0"), customer.ContactPhone.Substring(9));
        }
    }
}
