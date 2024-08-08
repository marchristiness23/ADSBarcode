using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHUNetMVC.Abstraction.Repositories
{
    public interface IEmployeeKendoRepository : IGenericRepository<Employee>
    {
        Task DeleteEmployee(int empId);
        Task<List<Employee>> GetAll(int page, int limit);
        Task<int> GetTotalCount();
    }
}
