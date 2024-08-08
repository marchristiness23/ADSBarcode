using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Model.Entities;
using SHUNetMVC.Abstraction.Model.Response;
using SHUNetMVC.Abstraction.Model.View;
using SHUNetMVC.Abstraction.Repositories;
using SHUNetMVC.Infrastructure.EntityFramework.Queries;
using Dapper;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace SHUNetMVC.Infrastructure.EntityFramework.Repositories
{
    public abstract class BaseCrudRepository<TEntity,TDto,TGridModel,TCrudQuery> : BaseRepository  
        where TCrudQuery : BaseCrudQuery
        where TEntity : class
        where TDto :  BaseDtoAutoMapper<TEntity>

    {
        private TCrudQuery _crudQuery;
      
        public BaseCrudRepository(DB_PHE_ADSEntities context, IConnectionProvider connection, TCrudQuery tCrudQuery) 
            : base(context, connection)
        {
            _crudQuery = tCrudQuery;
        }

        public virtual async Task Create(TDto dto)
        {
            try
            {
                var entity = dto.ToEntity();
                _context.Set<TEntity>().Add(entity);
                _context.Set<TEntity>().Attach(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
          
        }

        public virtual async Task<TDto> GetOne(int id) 
        {
            TEntity result = await _context.Set<TEntity>().FindAsync(id);
            TDto dto =  (TDto)Activator.CreateInstance(typeof(TDto), result);
            return dto;
        }

        public virtual async Task Delete(int id)
        {
            var item = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Remove(item);
          await   _context.SaveChangesAsync();

        }

        public virtual Task<LookupList> GetAdaptiveFilterList(string columnId)
        {
            throw new System.NotImplementedException();
        }
     

        public virtual async Task<Paged<TGridModel>> GetPaged(GridParam param)
        {
            return await GetPaged<TGridModel>(
               _crudQuery.SelectPagedQuery,
               _crudQuery.CountQuery,

               param.ColumnDefinitions,
               param.FilterList.FilterItems,
               param.FilterList.Page,
               param.FilterList.Size,
               param.FilterList.OrderBy);
        }

        public virtual async Task Update(TDto dto)
        {
            TEntity model = dto.ToEntity();
            _context.Set<TEntity>().AddOrUpdate(model);
            await _context.SaveChangesAsync();
        }


        public virtual async Task<string> GetLookupText(int id)
        {
            using (var connection = OpenConnection())
            {
                var querySQL = string.Format(_crudQuery.LookupTextQuery,id);
                var lookupText = await connection.QueryFirstOrDefaultAsync<string>(querySQL);
                if (lookupText == null)
                {
                    lookupText = "";
                }
                return lookupText;
            }
        }
    }
}
