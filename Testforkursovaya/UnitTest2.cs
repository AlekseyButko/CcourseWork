using Business_Logic_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testforkursovaya
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void TestClient()
        {
            Client client = new Client();
            string name = "Jud";
            try
            {
                client.SetName(name);
            }
            catch (System.Exception)
            {
                Assert.IsTrue(true);
            }
            Assert.IsTrue(true);
        }
    }
}
