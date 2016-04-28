using System;
using System.Linq;
using ComputerService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputerServiceTest
{
    [TestClass]
    public class DeviceTest
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
            "dbo.Table",
            DataAccessMethod.Sequential)]
        public void SetNextApplicationNumberTest()
        {
            // arrange
            string name = Convert.ToString(TestContext.DataRow["Name"]);
            string type = Convert.ToString(TestContext.DataRow["Type"]);
            DateTime registerDate = Convert.ToDateTime(TestContext.DataRow["RegisterDate"]).Date;
            bool state = Convert.ToBoolean(TestContext.DataRow["State"]);

            Device device = new Device(name, type, registerDate, state);

            DeviceManager deviceManager = new DeviceManager();

            int expectedApplicationNumber = Convert.ToInt32(TestContext.DataRow["ExpectedApplicationNumber"]);

            // act
            deviceManager.SetNextApplicationNumber(device);

            // assert
            int actualApplicationNumber = device.ApplicationNumber;
            Assert.AreEqual(actualApplicationNumber, expectedApplicationNumber);
        }

        [TestMethod]
        public void SetNextApplicationNumberAtBlankListTest()
        {
            // arrange
            const int applicationNumber = 1;
            const string name = "Dell Vostro";
            const string type = "Notebook";
            DateTime registerDate = new DateTime(2016, 3, 15);
            const bool state = false;

            Device device = new Device(applicationNumber, name, type, registerDate, state);

            DeviceManager deviceManager = new DeviceManager();

            deviceManager.AddDevice(device);

            const string name1 = "Dell Vostro";
            const string type1 = "Notebook";
            DateTime registerDate1 = new DateTime(2016, 3, 15);
            const bool state1 = false;

            Device device1 = new Device(name1, type1, registerDate1, state1);

            const int expectedApplicationNumber = 2;

            // act
            deviceManager.SetNextApplicationNumber(device1);

            // assert
            int actualApplicationNumber = device1.ApplicationNumber;
            Assert.AreEqual(actualApplicationNumber, expectedApplicationNumber);
        }

        [TestMethod]
        public void AddDeviceTest()
        {
            // arrange
            const int applicationNumber = 1;
            const string name = "Dell Vostro";
            const string type = "Notebook";
            DateTime registerDate = new DateTime(2016, 3, 15);
            const bool state = false;

            Device device = new Device(applicationNumber, name, type, registerDate, state);

            DeviceManager deviceManager = new DeviceManager();

            // act
            deviceManager.AddDevice(device);

            // assert
            Device addedDevice = deviceManager.devices.Last();
            Assert.AreEqual(device, addedDevice);
        }

        [TestMethod]
        public void GetDeviceByApplicationNumberTest()
        {
            // arrange
            const int applicationNumber = 1;
            const string name = "Dell Vostro";
            const string type = "Notebook";
            DateTime registerDate = new DateTime(2016, 3, 15);
            const bool state = false;

            Device device = new Device(applicationNumber, name, type, registerDate, state);

            DeviceManager deviceManager = new DeviceManager();

            deviceManager.AddDevice(device);

            // act
            Device obtainedDevice = deviceManager.GetDeviceByApplicationNumber(applicationNumber);

            // assert
            Assert.AreEqual(device, obtainedDevice);
        }

        [TestMethod]
        public void CheckDeviceStatusTest()
        {
            // arrange
            const int applicationNumber = 1;
            const string name = "Dell Vostro";
            const string type = "Notebook";
            DateTime registerDate = new DateTime(2016, 3, 15);
            const bool state = false;

            Device device = new Device(applicationNumber, name, type, registerDate, state);

            DeviceManager deviceManager = new DeviceManager();

            //act
            bool deviceStatus = deviceManager.CheckDeviceStatus(device);

            //assert
            Assert.IsFalse(deviceStatus);

        }

        [TestMethod]
        public void SetRepairDateTest()
        {
            // arrange
            const int applicationNumber = 1;
            const string name = "Dell Vostro";
            const string type = "Notebook";
            DateTime registerDate = new DateTime(2016, 3, 15);
            const bool state = false;

            Device device = new Device(applicationNumber, name, type, registerDate, state);

            DeviceManager deviceManager = new DeviceManager();

            DateTime currentTime = DateTime.Parse("2016, 3, 16").Date;

            ICurrentTimeGetter currentTimeGetter = new ComputerService.Fakes.StubICurrentTimeGetter()
            {
                GetCurrentTime = () => { return currentTime; }
            };

            // act
            deviceManager.SetRepairDate(device, currentTimeGetter);

            // assert
            Assert.AreEqual(currentTime, device.RepairDate);
        }

        [TestMethod]
        public void ChangeDeviceStatusToTrueTest()
        {
            // arrange
            const int applicationNumber = 1;
            const string name = "Dell Vostro";
            const string type = "Notebook";
            DateTime registerDate = new DateTime(2016, 3, 15);
            const bool state = false;

            Device device = new Device(applicationNumber, name, type, registerDate, state);

            DeviceManager deviceManager = new DeviceManager();

            // act
            deviceManager.ChangeDeviceStatus(device);

            // assert
            Assert.IsTrue(device.State);
        }

        [TestMethod]
        public void ChangeDeviceStatusToFalseTest()
        {
            // arrange
            const int applicationNumber = 1;
            const string name = "Dell Vostro";
            const string type = "Notebook";
            DateTime registerDate = new DateTime(2016, 3, 15);
            const bool state = true;

            Device device = new Device(applicationNumber, name, type, registerDate, state);

            DeviceManager deviceManager = new DeviceManager();

            // act
            deviceManager.ChangeDeviceStatus(device);

            // assert
            Assert.IsFalse(device.State);
        }

        [TestMethod]
        public void SetClientToDeviceTest()
        {
            // arrange
            const string peselNumber = "24241241242";
            Client expectedClient = new Client(1, "Jan", "Kowalski", "214412412421", peselNumber);

            IClient client = new ComputerService.Fakes.StubIClient()
            {
                GetClientString = (pesel) => expectedClient
            };

            const int applicationNumber = 1;
            const string name = "Dell Vostro";
            const string type = "Notebook";
            DateTime registerDate = new DateTime(2016, 3, 15);
            const bool state = false;

            Device device = new Device(applicationNumber, name, type, registerDate, state);

            DeviceManager deviceManager = new DeviceManager();

            // act
            deviceManager.SetClientToDevice(client, device, peselNumber);

            // assert
            Assert.AreEqual(expectedClient, device.Client);
        }

        [TestMethod]
        public void SetTechnicianToDeviceTest()
        {
            // arrange
            const int techniciansId = 1;
            Technician expectedTechnician = new Technician(techniciansId, "Jan", "Nowak", 2000);

            ITechnician technician = new ComputerService.Fakes.StubITechnician()
            {
                GetTechnicianByIdInt32 = (id) => expectedTechnician
            };

            const int applicationNumber = 1;
            const string name = "Dell Vostro";
            const string type = "Notebook";
            DateTime registerDate = new DateTime(2016, 3, 15);
            const bool state = false;

            Device device = new Device(applicationNumber, name, type, registerDate, state);

            DeviceManager deviceManager = new DeviceManager();

            // act
            deviceManager.SetTechnicianToDevice(technician, device, techniciansId);

            // assert
            Assert.AreEqual(expectedTechnician, device.Technician);
        }
    }
}
