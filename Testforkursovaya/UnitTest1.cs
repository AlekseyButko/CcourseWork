using Business_Logic_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testforkursovaya
{
    [TestClass]
    public class TestClient
    {
        PropertyManagement pm = new PropertyManagement();
        [TestMethod]
        public void AddOffer()
        {

            Client cl = new Client("Name", "SurName", 3);
            pm.AddProperty(Property.PropertyType.CountryHouse, 1000);
            pm.AddProperty(Property.PropertyType.CountryHouse, 1100);
            cl.AddOffer(1, pm);
            Assert.AreEqual(new Property(Property.PropertyType.CountryHouse,1000,1).ID, cl.GetOffersList()[0].ID);
            Assert.AreEqual(new Property(Property.PropertyType.CountryHouse, 1000, 1).Cost, cl.GetOffersList()[0].Cost);
            //Assert.AreEqual(new Property(Property.PropertyType.CountryHouse, 1100, 2).ID, cl.GetOffersList()[1].ID);
            //Assert.AreEqual(new Property(Property.PropertyType.CountryHouse, 1100, 2).Cost, cl.GetOffersList()[1].Cost);



        }
        [TestMethod]
        public void GetClient()
        {
            ClientManagement km = new ClientManagement();
            km.AddClient("Name", "SurName");
            km.AddClient("Name1", "SurName1");
            Client expected = km.GetClient(1);
            Client expected1 = km.GetClient(2);
            Assert.AreEqual("Name", expected.Name);
            Assert.AreEqual("SurName1", expected1.Surname);


        }
        [TestMethod]
        public void DeleteClient()
        {
            ClientManagement km = new ClientManagement();
            km.AddClient("Name", "SurName");
            km.AddClient("Name1", "SurName1");
            km.DeleteClient(2);
            Client expected = km.GetClient(1);
           
            Assert.ThrowsException<Exception>(() => km.DeleteClient(2));
            Assert.ThrowsException<Exception>(() => km.DeleteClient(3));
            Assert.AreEqual("SurName", expected.Surname);


        }
        [TestMethod]
        public void ChangeClientInfo()
        {
            ClientManagement km = new ClientManagement();
            
            km.AddClient("Name1", "SurName1");
            km.ChangeClientInfo(1, "Name","SurName");

            Client expected = km.GetClient(1);

            Assert.AreEqual("Name", expected.Name);
            Assert.AreEqual("SurName", expected.Surname);


        }
        [TestMethod]
        public void GetClientInfo()
        {
            ClientManagement km = new ClientManagement();
            km.AddClient("Name", "SurName");
            km.AddClient("Name1", "SurName1");
            Client cl = new Client("Name1","SurName1",2);
            string str = km.GetClientInfo(2);

            Assert.AreEqual(cl.ToString(), str );
            Assert.ThrowsException<Exception>(() => km.GetClientInfo(3));



        }

    }
}
