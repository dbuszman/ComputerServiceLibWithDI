using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService
{
    public class ClientManager : IClient
    {
        public List<Client> clients = new List<Client>();
        
        public void PrepareCorrectIdClient(Client client, IChecker idChecker)
        {
            while (idChecker.CheckClientIdExistance(this, client.IdClient))
            {
                client.IdClient++;
            }
        }

        public void AddClient(Client client)
        {
            clients.Add(client);
        }

        public Client GetClient(string pesel)
        {
            return clients.FirstOrDefault(client => client.Pesel.Equals(pesel));
        }

        public List<Client> GetAllClients()
        {
            return clients;
        }

        public void UpdateClientTelephone(Client client, string newTelephone)
        {
            foreach (var c in clients.Where(c => c.Equals(client)))
            {
                c.TelephoneNumber = newTelephone;
            }
        }
    }
}
