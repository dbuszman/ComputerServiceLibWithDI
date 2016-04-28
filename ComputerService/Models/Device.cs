using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService
{
    public class Device
    {
        public int ApplicationNumber;
        public string Name;
        public string Type;
        public DateTime RegisterDate;
        public DateTime? RepairDate;
        public bool State;
        public Client Client;
        public Technician Technician;

        public Device(int applicationNumber, string name, string type, DateTime registerDate, bool state)
        {
            ApplicationNumber = applicationNumber;
            Name = name;
            Type = type;
            RegisterDate = registerDate;
            State = state;
        }

        public Device(string name, string type, DateTime registerDate, bool state)
        {
            Name = name;
            Type = type;
            RegisterDate = registerDate;
            State = state;
        }
    }
}
