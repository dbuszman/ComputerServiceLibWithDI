using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService
{
    public class DeviceManager : IDevice
    {
        public List<Device> devices = new List<Device>();

        public void SetNextApplicationNumber(Device device)
        {
            if (devices.Count != 0)
            {
                int lastApplicationNumber = devices.Last().ApplicationNumber;

                device.ApplicationNumber = lastApplicationNumber + 1;
            }
            else
            {
                device.ApplicationNumber = 1;
            }
        }

        public void AddDevice(Device device)
        {
            devices.Add(device);
        }

        public Device GetDeviceByApplicationNumber(int applicationNumber)
        {
            return devices.Find(dev => dev.ApplicationNumber == applicationNumber);
        }

        public bool CheckDeviceStatus(Device device)
        {
            return device.State;
        }

        public void SetRepairDate(Device device, ICurrentTimeGetter currentTime)
        {
            device.RepairDate = currentTime.GetCurrentTime();
        }

        public void ChangeDeviceStatus(Device device)
        {
            if (device.State)
            {
                device.State = false;
            }
            else
            {
                device.State = true;
            }
        }

        public void SetClientToDevice(IClient client, Device device, string clientsPesel)
        {
            Client matchedClient = client.GetClient(clientsPesel);
            device.Client = matchedClient;
        }

        public void SetTechnicianToDevice(ITechnician technician, Device device, int techniciansId)
        {
            Technician matchedTechnician = technician.GetTechnicianById(techniciansId);
            device.Technician = matchedTechnician;
        }
    }
}
