using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService
{
    public interface IClient
    {
        void PrepareCorrectIdClient(Client client, IChecker idChecker);
        void AddClient(Client client);
        Client GetClient(string pesel);
        List<Client> GetAllClients(); 
        void UpdateClientTelephone(Client client, string newTelephone);
    }
}
