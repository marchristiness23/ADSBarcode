using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Model.Entities;
using SHUNetMVC.Abstraction.Model.Response;
using SHUNetMVC.Abstraction.Repositories;
using SHUNetMVC.Abstraction.Services; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHUNetMVC.Infrastructure.Services
{
    public class EmployeeService : BaseCrudService<EmployeeDto, EmployeeWithDepartement>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository repo) : base(repo)
        {
            _employeeRepository = repo;
        }
  

        public List<Employee> GetByName(string name)
        {
            return _employeeRepository.GetByName(name);
        }
    }
}
