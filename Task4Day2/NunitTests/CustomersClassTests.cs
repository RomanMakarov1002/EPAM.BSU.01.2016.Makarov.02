using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task4;
using  static Task4.Customer;


namespace NunitTests
{
    [TestFixture]
    public class CustomersClassTests
    {
        [Test]
        public void CustomerToString_Test()
        {
            Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);

            string[] testFormats = new string[3] {"123","12","13"};
            string[] expectedResults = new string[3];
            decimal revenue = 1000000;
            expectedResults[0]= "Customer record: Jeffrey Richter, " + revenue.ToString("N0") + ", +1 (425) 555-0100";
            expectedResults[1] = "Customer record: Jeffrey Richter, " + revenue.ToString("N0");
            expectedResults[2] = "Customer record: Jeffrey Richter, +1 (425) 555-0100";
            for (int i = 0; i < testFormats.Length; i++)
                Assert.AreEqual(expectedResults[i], customer.ToString(testFormats[i]));
        }

        [Test]
        public void NameFormatter_Test()
        {
            Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            string expecterResult = "Customer record: Jeffrey, " +
                                    customer.Revenue.ToString("N0") + ", +1 (425) 555-0100";
            Assert.AreEqual(expecterResult,customer.NameFormatter(7));
        }

        [Test]
        public void PhoneFormatter_Test()
        {
            Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            string expecterResult = "Customer record: Jeffrey Richter, " +
                                    customer.Revenue.ToString("N0") + ", 555-0100";
            Assert.AreEqual(expecterResult, customer.PhoneFormatter());
        }
    }
    
}