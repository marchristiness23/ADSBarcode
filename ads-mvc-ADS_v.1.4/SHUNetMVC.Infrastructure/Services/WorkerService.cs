using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Repositories;
using SHUNetMVC.Abstraction.Services;
 
using System.Threading.Tasks;

namespace SHUNetMVC.Infrastructure.Services
{
    public class WorkerService : BaseCrudService<WorkerDto, WorkerDto>, IWorkerService
    {
        private readonly IWorkerRepository _repo;
        public WorkerService(IWorkerRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public void Destroy(int employeeID)
        {
            _repo.Destroy(employeeID);
        }
    }
}
