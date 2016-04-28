using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService
{
    public class Technician
    {
        public int IdTechnician;
        public string Firstname;
        public string Surname;
        public int Salary;

        public Technician(int idTechnician, string firstname, string surname, int salary)
        {
            IdTechnician = idTechnician;
            Firstname = firstname;
            Surname = surname;
            Salary = salary;
        }
    }
}
