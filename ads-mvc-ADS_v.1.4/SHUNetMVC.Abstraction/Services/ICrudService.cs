using SHUNetMVC.Abstraction.Model.Response;
using SHUNetMVC.Abstraction.Model.View;
using ClosedXML.Excel;
using System.Threading.Tasks;

namespace SHUNetMVC.Abstraction.Services
{
    public interface ICrudService<TEntity, TGridModel>
    {
        Task<TEntity> GetOne(int id);
        Task Update(TEntity model);
        Task Delete(int id);
        Task Create(TEntity model);
        Task<string> GetLookupText(int id);
        Task<Paged<TGridModel>> GetPaged(GridParam param);
        Task<LookupList> GetAdaptiveFilterList(string columnId);
        Task<XLWorkbook> ExportToExcel(GridParam param);
        byte[] ExportToPDF(GridListModel model, string headerText, int[] tableHeaderSizes);
    }
}
