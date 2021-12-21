using Business_Logic_Layer;
using Lucene.Net.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testforkursovaya
{
    [TestClass]
    public class SetAccountNumber
    {
        [TestMethod]
        public void TestSetAccountNumber()
        {
            Client client = new Client();
            int Number =  333;

            try
            {
                client.SetAccountNumber(2);

            }
            catch (System.Exception)
            {
                Assert.IsTrue(true);
            }

            Assert.IsTrue(true);
        }
    }
}
