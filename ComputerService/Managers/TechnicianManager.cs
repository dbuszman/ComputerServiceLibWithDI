using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService
{
    public class TechnicianManager : ITechnician
    {
        public List<Technician> technicians = new List<Technician>();
        public void PrepareCorrectIdTechnician(Technician technician, IChecker idChecker)
        {
            while (idChecker.CheckTechnicianIdExistance(this, technician.IdTechnician))
            {
                technician.IdTechnician++;
            }
        }

        public void AddTechnician(Technician technician)
        {
            technicians.Add(technician);
        }

        public Technician GetTechnicianById(int idTechnician)
        {
            return technicians.FirstOrDefault(technician => technician.IdTechnician.Equals(idTechnician));
        }

        public List<Technician> GetAllTechnicians()
        {
            return technicians;
        }

        public void UpdateTechnicianSalary(Technician technician, int newSalary)
        {
            foreach (var c in technicians.Where(t => t.Equals(technician)))
            {
                c.Salary = newSalary;
            }
        }
    }
}
