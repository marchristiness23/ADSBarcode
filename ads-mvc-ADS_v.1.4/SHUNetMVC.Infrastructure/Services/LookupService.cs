using SHUNetMVC.Abstraction.Model.View;
using SHUNetMVC.Abstraction.Repositories;
using SHUNetMVC.Abstraction.Services; 

namespace SHUNetMVC.Infrastructure.Services
{
    public class LookupService : ILookupService
    {
        private readonly ILookupRepository _repo;
        //private readonly ILogger _logger;

        public LookupService(ILookupRepository repo)
        {
            _repo = repo;
           // _logger = logger;
        }
 

        public LookupList GetDepartements()
        {
            return _repo.GetDepartements();
        }

        public LookupList GetProjects()
        {
            return null;// _repo.GetProjects();
        }
    }
}
