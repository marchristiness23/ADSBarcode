using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Model.Entities;
using SHUNetMVC.Abstraction.Model.Response;
using SHUNetMVC.Abstraction.Model.View;
using SHUNetMVC.Abstraction.Repositories;
using SHUNetMVC.Infrastructure.EntityFramework.Queries;
using Dapper;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using System;

namespace SHUNetMVC.Infrastructure.EntityFramework.Repositories
{
    public class CrudEmployeeKendoRepository : BaseCrudRepository<Employee,EmployeeDto, EmployeeDto, EmployeeQuery>, ICrudEmployeeKendoRepository
    {
        public CrudEmployeeKendoRepository(DB_PHE_ADSEntities context, IConnectionProvider connection)
            : base(context, connection, new EmployeeQuery())
        {
        }

        public override async Task Create(EmployeeDto model)
        {
            var entity = model.ToEntity();
            try
            {
                _context.Employees.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
