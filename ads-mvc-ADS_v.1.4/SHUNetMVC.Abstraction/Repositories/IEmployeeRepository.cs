using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Model.Entities;
using SHUNetMVC.Abstraction.Model.Response;
using System.Collections.Generic;

namespace SHUNetMVC.Abstraction.Repositories
{
    public interface IEmployeeRepository : ICrudRepository<EmployeeDto, EmployeeWithDepartement>
    {
        List<Employee> GetByName(string name);
    }
}
