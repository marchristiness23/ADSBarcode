using SHUNetMVC.Abstraction.Model.Response;
using SHUNetMVC.Abstraction.Model.View;
using System.Threading.Tasks;

namespace SHUNetMVC.Abstraction.Repositories
{
    public interface ICrudRepository<TDto, TGridModel>
    {
        Task Create(TDto model);
        Task Update(TDto model);
        Task Delete(int id);
        Task<Paged<TGridModel>> GetPaged(GridParam param);
        Task<TDto> GetOne(int id);
        Task<string> GetLookupText(int id);
        Task<LookupList> GetAdaptiveFilterList(string columnId);
    }
}
