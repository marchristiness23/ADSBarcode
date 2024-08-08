using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Repositories;
using SHUNetMVC.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHUNetMVC.Infrastructure.Services
{
    public class CommonService : ICommonService
    {
        private ICommonRepository _commonRepository;
        public CommonService(ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;
        }
        public async Task<List<DepartementDto>> GetDepartement()
        {
            List<DepartementDto> result = new List<DepartementDto>();
            var data = await _commonRepository.GetDataDepartement();
            foreach(var value in data)
            {
                var dto = new DepartementDto
                {
                    DepartementId = value.DepartementId,
                    DepartementName = value.DepartementName
                };
                result.Add(dto);
            }
            return result;
        }
    }
}
