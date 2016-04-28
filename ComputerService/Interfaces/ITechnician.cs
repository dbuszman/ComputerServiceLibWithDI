using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService
{
    public interface ITechnician
    {
        void PrepareCorrectIdTechnician(Technician technician, IChecker idChecker);
        void AddTechnician(Technician technician);
        Technician GetTechnicianById(int IdTechnician);
        List<Technician> GetAllTechnicians(); 
        void UpdateTechnicianSalary(Technician technician, int newSalary);
    }
}
