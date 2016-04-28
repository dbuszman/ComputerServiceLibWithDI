using System;
using System.Collections.Generic;
using System.Linq;
using ComputerService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputerServiceTest
{
    [TestClass]
    public class ClientTest
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        [TestMethod]
        [DataSource("System.Data.SqlClient",
            @"Data Source=(localdb)\ProjectsV12;Initial Catalog=DataDriven;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
            "dbo.Client",
            DataAccessMethod.Random)]
        public void PrepareCorrectIdClientTest()
        {
            // arrange
            int idClient = Convert.ToInt32(TestContext.DataRow["idClient"]);
            const string firstname = "Jan";
            const string surname = "Kowalski";
            const string telephone = "2132123133";
            const string pesel = "2142421412421";

            int maxIdValue = Convert.ToInt32(TestContext.DataRow["maxIdValue"]);

            Client client = new Client(idClient, firstname, surname, telephone, pesel);

            ClientManager clientManager = new ClientManager();

            IChecker checker = new ComputerService.Fakes.StubIChecker()
            {
                CheckClientIdExistanceIClientInt32 = (iclient, id) =>
                {
                    if (client.IdClient <= maxIdValue)
                    {
                        return true;
                    }
                    return false;
                }
            };

            int expectedId = Convert.ToInt32(TestContext.DataRow["expectedId"]);

            clientManager.PrepareCorrectIdClient(client, checker);

            Assert.AreEqual(expectedId, client.IdClient);
        }

        [TestMethod]
        public void AddClientTest()
        {
            // arrange
            const int idClient = 1;
            const string firstname = "Jan";
            const string surname = "Kowalski";
            const string telephone = "2132123133";
            const string pesel = "2142421412421";

            Client client = new Client(idClient, firstname, surname, telephone, pesel);

            ClientManager clientManager = new ClientManager();

            // act
            clientManager.AddClient(client);
            
            // assert
            Client addedClient = clientManager.clients.Last();
            Assert.AreEqual(client, addedClient);
        }

        [TestMethod]
        public void GetAllTest()
        {
            // arrange
            const int idClient = 1;
            const string firstname = "Jan";
            const string surname = "Kowalski";
            const string telephone = "2132123133";
            const string pesel = "2142421412421";

            Client client = new Client(idClient, firstname, surname, telephone, pesel);

            ClientManager clientManager = new ClientManager();
            
            clientManager.AddClient(client);

            List<Client> expectedCollection = clientManager.clients;

            // act
            List<Client> allClients = clientManager.GetAllClients();

            // assert
            CollectionAssert.AreEquivalent(expectedCollection, allClients);
        }

        [TestMethod]
        public void GetClientByPeselCheck()
        {
            // arrange
            const int idClient = 1;
            const string firstname = "Jan";
            const string surname = "Kowalski";
            const string telephone = "2132123133";
            const string pesel = "2142421412421";

            Client client = new Client(idClient, firstname, surname, telephone, pesel);

            ClientManager clientManager = new ClientManager();

            clientManager.AddClient(client);

            // act
            Client obtainedClient = clientManager.GetClient(pesel);

            // assert
            Assert.AreEqual(client, obtainedClient);
        }

        [TestMethod]
        public void UpdateClientTelephoneCheck()
        {
            // arrange
            const int idClient = 1;
            const string firstname = "Jan";
            const string surname = "Kowalski";
            const string telephone = "2132123133";
            const string pesel = "2142421412421";

            const string newTelephone = "513312133";

            Client client = new Client(idClient, firstname, surname, telephone, pesel);

            ClientManager clientManager = new ClientManager();

            clientManager.AddClient(client);

            // act
            clientManager.UpdateClientTelephone(client, newTelephone);

            // assert
            Client updatedClient = clientManager.clients.Find(c => c.Pesel == pesel);

            Assert.AreEqual(newTelephone, updatedClient.TelephoneNumber);
        }
    }
}
