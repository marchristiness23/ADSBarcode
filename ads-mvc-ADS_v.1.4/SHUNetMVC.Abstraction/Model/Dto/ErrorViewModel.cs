using SHUNetMVC.Abstraction.Extensions;
using SHUNetMVC.Abstraction.Model.Entities;
using System.Collections.Generic;

namespace SHUNetMVC.Abstraction.Model.Dto
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }

}
