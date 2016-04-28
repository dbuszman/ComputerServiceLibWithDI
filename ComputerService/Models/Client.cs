using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService
{
    public class Client
    {
        public int IdClient;
        public string Firstname;
        public string Surname;
        public string TelephoneNumber;
        public string Pesel;

        public Client(int idClient, string firstname, string surname, string telephone, string pesel)
        {
            IdClient = idClient;
            Firstname = firstname;
            Surname = surname;
            TelephoneNumber = telephone;
            Pesel = pesel;
        }
    }
}
