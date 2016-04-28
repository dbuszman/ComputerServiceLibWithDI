using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace ComputerService
{
    public class ClientManager : ICrud<Client>
    {
        Dal databasesDal = RegisterContainer.objContainer.Resolve<Dal>();
        //stubs do bazy
        public void Create(Client client)
        {
            databasesDal.Clients.Add(client);
            databasesDal.SaveChanges();
        }

        public List<Client> Retrieve()
        {
            var clients = from i in databasesDal.Clients select i;

            return clients.ToList();
        }

        public void Update(Client client, string newFirstname)
        {
            client.Firstname = newFirstname;

            databasesDal.Entry(client).State = EntityState.Modified;
            databasesDal.SaveChanges();
        }

        public void Delete(Client client)
        {
            databasesDal.Clients.Remove(client);
            databasesDal.SaveChanges();
        }
    }
}
