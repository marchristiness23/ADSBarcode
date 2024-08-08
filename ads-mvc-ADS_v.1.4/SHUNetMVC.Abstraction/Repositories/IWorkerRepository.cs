using SHUNetMVC.Abstraction.Model.Dto;
using System.Threading.Tasks;

namespace SHUNetMVC.Abstraction.Repositories
{
    public interface IWorkerRepository : ICrudRepository<WorkerDto, WorkerDto>
    {
        void Destroy(int employeeID);
    }
}
