using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService
{
    interface IDevice
    {
        void SetNextApplicationNumber(Device device);
        void AddDevice(Device device);
        Device GetDeviceByApplicationNumber(int applicationNumber);
        bool CheckDeviceStatus(Device device);
        void SetRepairDate(Device device, ICurrentTimeGetter currentTime);
        void ChangeDeviceStatus(Device device);
        void SetClientToDevice(IClient client, Device device, string clientsPesel);
        void SetTechnicianToDevice(ITechnician technician, Device device, int techniciansId);
    }
}
