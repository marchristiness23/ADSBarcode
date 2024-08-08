using SHUNetMVC.Abstraction.Model.Entities;
using SHUNetMVC.Abstraction.Model.Response;
using SHUNetMVC.Abstraction.Model.View;
using SHUNetMVC.Abstraction.Repositories;
using SHUNetMVC.Abstraction.Services;
using SHUNetMVC.Infrastructure.Helpers;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel; 
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using QuestPDF.Drawing;

namespace SHUNetMVC.Infrastructure.Services
{
    public class BaseCrudService<TDto, TGridModel> : ICrudService<TDto,TGridModel>
    {
        private readonly ICrudRepository<TDto, TGridModel> _repo;
        
        public BaseCrudService(ICrudRepository<TDto, TGridModel> repo)
        {
            _repo = repo; 
        }

        public Task<Paged<TGridModel>> GetPaged(GridParam param)
        {
            //_logger.Information($"Get employee list with departement page {param.FilterList.Page}");
            return _repo.GetPaged(param);
        }

        public Task<LookupList> GetAdaptiveFilterList(string columnId)
        {
           // _logger.Information($"Get adaptive filter list column {columnId}");
            return _repo.GetAdaptiveFilterList(columnId);
        }

        public async Task<XLWorkbook> ExportToExcel(GridParam param)
        {
            //_logger.Information($"Get employee list with departement report");

            param.FilterList.Page = 1;
            param.FilterList.Size = 10000;

            var data = await _repo.GetPaged(param);
            return SpreadsheetGenerator.Generate("Master Data Employee", data.Items, param.ColumnDefinitions, param.FilterList);
        }

        public byte[] ExportToPDF(GridListModel gridList, string headerText, int[] tableHeaderSizes)
        {
            //_logger.Information($"Get employee list with departement PDF report");

            PDFTableGenerator pdfTable = new PDFTableGenerator(gridList, headerText, tableHeaderSizes);
            return pdfTable.GeneratePdf();
        }

        public async Task Create(TDto model)
        {
            await _repo.Create(model);
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<TDto> GetOne(int id)
        {
            return await _repo.GetOne(id);
        }

        public async Task Update(TDto model)
        {
            await _repo.Update(model);
        }

        public async Task<string> GetLookupText(int id)
        {
            return await _repo.GetLookupText(id);
        }
    }
}
