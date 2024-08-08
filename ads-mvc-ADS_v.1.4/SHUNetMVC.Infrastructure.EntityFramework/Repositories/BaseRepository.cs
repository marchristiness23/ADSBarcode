using SHUNetMVC.Abstraction.Model.Entities;
using SHUNetMVC.Abstraction.Model.Response;
using SHUNetMVC.Abstraction.Model.View;
using SHUNetMVC.Abstraction.Repositories;
using SHUNetMVC.Infrastructure.EntityFramework.Queries;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;  

namespace SHUNetMVC.Infrastructure.EntityFramework.Repositories
{
    public class BaseRepository
    {
        protected readonly DB_PHE_ADSEntities _context;
        private readonly IConnectionProvider _connection;

        public BaseRepository(DB_PHE_ADSEntities context, IConnectionProvider connection)
        {
            _context = context;
            _connection = connection;
        }

        protected async Task<Paged<TPaged>> GetPaged<TPaged>(string selectQuery, string countQuery, List<ColumnDefinition> columnDefinitions, List<List<FilterItem>> param, int page = 1, int size = 10, string sort = "id asc")
        {
            using (var connection = OpenConnection())
            {
                var filterSql = FilterBuilder.BuildFilter(columnDefinitions,param);

                var metaData = InsertMetaData(selectQuery, filterSql, page, size, sort);

                var querySQL = BuildQuery(BaseQueries.PagedQuery, metaData);
                var items = await connection.QueryAsync<TPaged>(querySQL);
                metaData["select"] = countQuery;
                querySQL = BuildQuery(BaseQueries.CountQuery, metaData);
                var count = await connection.QueryFirstAsync<int>(querySQL);

                return new Paged<TPaged>()
                {
                    TotalItems = count,
                    Items = items
                };
            }
        }

        protected string BuildQuery(string sql, Dictionary<string, object> values)
        {
            var query = sql;
            foreach (var item in values)
            {
                query = query.Replace($"@{item.Key}", item.Value?.ToString());
            }
            return query.ToString();
        }

        protected virtual Dictionary<string, object> InsertMetaData(string selectQuery, string filterSql, int page, int size, string sort)
        {
            var metaData = new Dictionary<string, object>
            {
                { "select", selectQuery },
                { "sort", sort },
                { "offset", ((page - 1) * size) },
                { "limit", size },
                { "filter", filterSql }
            };

            return metaData;
        }

        protected async Task<IEnumerable<TResult>> ExecuteQueryAsync<TResult>(string query)
        {
            using (var connection = OpenConnection())
            {
                return await connection.QueryAsync<TResult>(query);
            }
        }

        protected IDbConnection OpenConnection()
        {
            SqlConnection conn;
            var connectionString = _connection.GetConnectionString(); 
            conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        } 
    }
}
