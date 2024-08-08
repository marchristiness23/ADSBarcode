using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Model.Entities;
using SHUNetMVC.Abstraction.Model.View;
using SHUNetMVC.Abstraction.Services;
using SHUNetMVC.Infrastructure.Services;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using FluentValidation;
using System.Linq;

namespace SHUNetMVC.Infrastructure.Validators
{
    public class EmployeeEducationValidator : AbstractValidator<EmployeeEducationDto>
    {
   
        public EmployeeEducationValidator()
        {
            RuleFor(model => model.School).NotEmpty();
        }

    }
}
