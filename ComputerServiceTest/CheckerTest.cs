using System;
using System.Collections.Generic;
using System.Configuration;
using ComputerService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputerServiceTest
{
    [TestClass]
    public class CheckerTest
    {
        [TestMethod]
        public void ClientIdExistanceCheck()
        {
            IdChecker idChecker = new IdChecker();
            List<Client> allClients = new List<Client>();
            allClients.Add(new Client(1, "Jan", "Kowalski", "214412412421", "24241241242"));
            
            IClient client = new ComputerService.Fakes.StubIClient()
            {
                GetAllClients = () => allClients
            };

            int idToCheck = 1;

            bool result = idChecker.CheckClientIdExistance(client, idToCheck);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TechnicianIdExistanceCheck()
        {
            IdChecker idChecker = new IdChecker();
            List<Technician> allTechnicians = new List<Technician>();
            allTechnicians.Add(new Technician(1, "Jan", "Nowak", 2800));

            ITechnician technician = new ComputerService.Fakes.StubITechnician()
            {
                GetAllTechnicians = () => allTechnicians
            };

            int idToCheck = 2;

            bool result = idChecker.CheckTechnicianIdExistance(technician, idToCheck);

            Assert.IsFalse(result);
        }
    }
}
