using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComputerService;

namespace ComputerServiceTest
{
    [TestClass]
    public class TechnicianTest
    {
        [TestMethod]
        public void PrepareCorrectIdTechnicianTest()
        {
            // arrange
            const int idTechnician = 125;
            const string firstname = "Jan";
            const string surname = "Kowalski";
            const int salary = 2000;

            const int maxIdValue = 150;

            Technician technician = new Technician(idTechnician, firstname, surname, salary);

            TechnicianManager technicianManager = new TechnicianManager();

            IChecker checker = new ComputerService.Fakes.StubIChecker()
            {
                CheckTechnicianIdExistanceITechnicianInt32 = (itechnician, id) =>
                {
                    if (technician.IdTechnician <= maxIdValue)
                    {
                        return true;
                    }
                    return false;
                }
            };

            const int expectedId = 151;

            // act
            technicianManager.PrepareCorrectIdTechnician(technician, checker);

            // assert
            Assert.AreEqual(expectedId, technician.IdTechnician);
        }

        [TestMethod]
        public void AddTechnicianTest()
        {
            // arrange
            const int idTechnician = 1;
            const string firstname = "Jan";
            const string surname = "Kowalski";
            const int salary = 2000;

            Technician technician = new Technician(idTechnician, firstname, surname, salary);

            TechnicianManager technicianManager = new TechnicianManager();

            // act
            technicianManager.AddTechnician(technician);

            // assert
            Technician addedTechnician = technicianManager.technicians.Last();
            Assert.AreEqual(technician, addedTechnician);
        }

        [TestMethod]
        public void GetAllTest()
        {
            // arrange
            const int idTechnician = 1;
            const string firstname = "Jan";
            const string surname = "Kowalski";
            const int salary = 2000;

            Technician technician = new Technician(idTechnician, firstname, surname, salary);

            TechnicianManager technicianManager = new TechnicianManager();

            technicianManager.AddTechnician(technician);

            List<Technician> expectedCollection = technicianManager.technicians;

            // act
            List<Technician> allTechnicians = technicianManager.GetAllTechnicians();

            // assert
            CollectionAssert.AreEquivalent(expectedCollection, allTechnicians);
        }

        [TestMethod]
        public void GetTechnicianByIdTest()
        {
            // arrange
            const int idTechnician = 1;
            const string firstname = "Jan";
            const string surname = "Kowalski";
            const int salary = 2000;

            Technician technician = new Technician(idTechnician, firstname, surname, salary);

            TechnicianManager technicianManager = new TechnicianManager();

            technicianManager.AddTechnician(technician);

            // act
            Technician obtainedTechnician = technicianManager.GetTechnicianById(idTechnician);

            // assert
            Assert.AreEqual(technician, obtainedTechnician);
        }

        [TestMethod]
        public void UpdateTechnicianSalaryCheck()
        {
            // arrange
            const int idTechnician = 1;
            const string firstname = "Jan";
            const string surname = "Kowalski";
            const int salary = 2000;

            const int newSalary = 2500;

            Technician technician = new Technician(idTechnician, firstname, surname, salary);

            TechnicianManager technicianManager = new TechnicianManager();

            technicianManager.AddTechnician(technician);

            // act
            technicianManager.UpdateTechnicianSalary(technician, newSalary);

            // assert
            Technician updatedTechnician = technicianManager.technicians.Find(c => c.IdTechnician == idTechnician);

            Assert.AreEqual(newSalary, updatedTechnician.Salary);
        }
    }
}
