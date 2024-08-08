using SHUNetMVC.Abstraction.Model.Entities;
using SHUNetMVC.Abstraction.Model.View;
using SHUNetMVC.Abstraction.Repositories;
using System.Linq;

namespace SHUNetMVC.Infrastructure.EntityFramework.Repositories
{
    public class LookupRepository : BaseRepository, ILookupRepository
    {

        public LookupRepository(DB_PHE_ADSEntities context, IConnectionProvider connection)
            : base(context, connection)
        {
        }

        public LookupList GetDepartements()
        {
            var list = _context.Departements.AsNoTracking()
                .OrderBy(o=>o.DepartementName)
                .Select(o => new LookupItem
            {
                Text = o.DepartementName,
                Value = o.DepartementId.ToString()
            }).ToList();

            return new LookupList
            {
                Items = list
            };
        }

        public LookupList GetProjects()
        {
            var list = _context.Projects.AsNoTracking()
                .OrderBy(o => o.ProjectName)
                .Select(o => new LookupItem
                {
                    Text = o.ProjectName,
                    Value = o.ProjectId.ToString()
                }).ToList();

            return new LookupList
            {
                Items = list
            };
        }
    }
}
