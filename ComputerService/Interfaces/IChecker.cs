using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService
{
    public interface IChecker
    {
        bool CheckClientIdExistance(IClient client, int idClient);
        bool CheckTechnicianIdExistance(ITechnician technician, int idTechnician);
    }
}
