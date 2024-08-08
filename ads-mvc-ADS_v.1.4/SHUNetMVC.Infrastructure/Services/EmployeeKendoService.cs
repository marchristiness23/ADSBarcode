using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Model.Entities;
using SHUNetMVC.Abstraction.Repositories;
using SHUNetMVC.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHUNetMVC.Infrastructure.Services
{
    public class EmployeeKendoService : IEmployeeKendoService
    {
        private IEmployeeKendoRepository _employeeRepository;
        public EmployeeKendoService(IEmployeeKendoRepository employeeKendoRepository)
        {
            _employeeRepository = employeeKendoRepository;
        }
        public async Task<List<EmployeeDto>> GetAll(int page, int limit)
        { 
            var data = await _employeeRepository.GetAll(page, limit); 
            var result = data.Select(employee => new EmployeeDto(employee)).ToList();
            return result;
        }

        public async Task<int> GetTotalCount()
        {
            return await _employeeRepository.GetTotalCount();
        }

        public async Task<EmployeeDto> GetById(int id)
        { 
            var data = await _employeeRepository.Find(x => x.EmpId == id);
            return data != null ? new EmployeeDto(data) : null; 
        }

        
        public async Task DeleteEmployee(int empId)
        {
            await _employeeRepository.DeleteEmployee(empId);
        }

    }
}
