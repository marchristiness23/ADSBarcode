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
    public class CommonRepository : ICommonRepository
    {
        private readonly DB_PHE_ADSEntities _context;
        private readonly IConnectionProvider _connection;

        public CommonRepository(DB_PHE_ADSEntities context, IConnectionProvider connection)
        {
            _context = context;
            _connection = connection;
        }
        public async Task<List<Departement>> GetDataDepartement()
        {
            return await _context.Departements.ToListAsync();
        }
    }
}
