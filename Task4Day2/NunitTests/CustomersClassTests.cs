using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustFormatProvider;
using NUnit.Framework;
using Task4;
using static Task4.Customer;
using System.Threading;

namespace NunitTests
{
    [TestFixture]
    public class CustomersClassTests
    {
        [Test]
        public void CustomerToString_Test()
        {
            Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);

            string[] testFormats = new string[4] {"nrp","n","NRP","r"};
            string[] expectedResults = new string[4];
            decimal revenue = 1000000;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            expectedResults[0] = "Jeffrey Richter " +revenue.ToString("C0")+ " +1 (425) 555-0100 ";
            expectedResults[1] = "Jeffrey Richter ";
            expectedResults[3] = customer.Revenue.ToString("C0") + " ";
            expectedResults[2] = "Jeffrey Richter " + revenue.ToString("C0") + " +1 (425) 555-0100 ";
            
            for (int i = 0; i < testFormats.Length; i++)
                Assert.AreEqual(expectedResults[i], customer.ToString(testFormats[i]));
        }

        [Test]
        public void NameFormatter_Test()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            string expecterResult = "Customer: Jeffrey Richter. Revenue: " +customer.Revenue.ToString("C") +". Phone: +1 (425) 555-0100. ";
            Assert.AreEqual(expecterResult,customer.ToString("nrp",new CustomFormatProvider()));
        }

       
    }
    
}