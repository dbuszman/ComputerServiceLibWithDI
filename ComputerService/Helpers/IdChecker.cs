using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService
{
    public class IdChecker : IChecker
    {
        public bool CheckClientIdExistance(IClient client, int idClient)
        {
            List<Client> allClients = client.GetAllClients();

            return allClients.Any(c => c.IdClient == idClient);
        }

        public bool CheckTechnicianIdExistance(ITechnician technician, int idTechnician)
        {
            List<Technician> allTechnicians = technician.GetAllTechnicians();

            return allTechnicians.Any(t => t.IdTechnician == idTechnician);
        }
    }
}
