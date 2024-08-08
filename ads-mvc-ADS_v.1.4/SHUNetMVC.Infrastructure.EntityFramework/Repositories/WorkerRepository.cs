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
    public class WorkerRepository : BaseCrudRepository<Worker,WorkerDto, WorkerDto, WorkerQuery>, IWorkerRepository
    {
        public WorkerRepository(DB_PHE_ADSEntities context, IConnectionProvider connection)
            : base(context, connection, new WorkerQuery())
        {
        }

        public override async Task Create(WorkerDto model)
        {
            var entity = model.ToEntity();
            try
            {
                _context.Workers.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Destroy(int employeeID)
        {
            var item = Task.Run(async () => await _context.Set<Worker>().FindAsync(employeeID)).Result;
            _context.Set<Worker>().Remove(item);
            Task.Run(async () => await _context.SaveChangesAsync());
        }
        public override async Task<LookupList> GetAdaptiveFilterList(string columnId)
        {
            var result = new LookupList
            {
                ColumnId = columnId
            };

            using (var connection = OpenConnection())
            {
                var items = await connection.QueryAsync<string>($"SELECT DISTINCT {columnId} FROM dbo.Workers ORDER BY {columnId}");

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
