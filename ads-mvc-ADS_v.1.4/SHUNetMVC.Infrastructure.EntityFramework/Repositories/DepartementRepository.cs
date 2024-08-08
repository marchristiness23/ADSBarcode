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
    public class DepartementRepository : BaseCrudRepository<Departement,DepartementDto, DepartementDto, DepartementQuery>, IDepartementRepository
    {
        public DepartementRepository(DB_PHE_ADSEntities context, IConnectionProvider connection)
            : base(context, connection, new DepartementQuery())
        {
        }

        public override async Task Create(DepartementDto model)
        {
            var entity = model.ToEntity();
            try
            {
                _context.Departements.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override async Task<LookupList> GetAdaptiveFilterList(string columnId)
        {
            var result = new LookupList
            {
                ColumnId = columnId
            };

            using (var connection = OpenConnection())
            {
                var items = await connection.QueryAsync<string>($"SELECT DISTINCT {columnId} FROM dbo.Departement ORDER BY {columnId}");

                result.Items = items.Select(item => new LookupItem
                {
                    Text = item,
                    Value = item
                }).ToList();
            }


            result.Items = result.Items.GroupBy(o => o.Text).Select(o => o.FirstOrDefault()).ToList();

            return result;
        }
    }
}
