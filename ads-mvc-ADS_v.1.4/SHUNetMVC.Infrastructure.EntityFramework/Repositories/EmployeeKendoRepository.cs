using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Model.Entities;
using SHUNetMVC.Abstraction.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHUNetMVC.Infrastructure.EntityFramework.Repositories
{
    public class EmployeeKendoRepository : GenericRepository<Employee>,IEmployeeKendoRepository
    {
        private readonly DB_PHE_ADSEntities _context;
        private readonly IConnectionProvider _connection;
        public EmployeeKendoRepository(DB_PHE_ADSEntities context, IConnectionProvider connection) : base(context, connection)
        {
            _context = context;
            _connection = connection;
        }
        public async Task<List<Employee>> GetAll(int page, int limit)
        {
            return await _context.Employees.Include("Departement").Include("EmployeeEducations").OrderBy(x => x.EmpId).Skip(limit * (page - 1)).Take(limit).ToListAsync();
        }

        public async Task<int> GetTotalCount() {
            return await _context.Employees.CountAsync();
        }

        public async Task DeleteEmployee(int empId)
        {
            var employee = await _context.Employees.FindAsync(empId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

    }
}
