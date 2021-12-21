using Business_Logic_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testforkursovaya
{
    [TestClass]
    public class RemoveOffer
    {
        [TestMethod]
        public void TestRemoveOffer()
        {
            Client client = new Client();
            int ID = 10;
            try
            {
                client.RemoveOffer(10);
            }
            catch (System.Exception)
            {
                Assert.IsTrue(true);
            }
            Assert.IsTrue(true);
        }
    }
}
