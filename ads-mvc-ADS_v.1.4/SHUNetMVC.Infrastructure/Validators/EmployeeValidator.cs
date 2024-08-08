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
    public class EmployeeValidator : AbstractValidator<EmployeeDto>
    {
        private IEmployeeService _employeeService;
        private FormState _state;

        public EmployeeValidator(FormState state, IEmployeeService employeeService)
        {
            _state = state;
            _employeeService = employeeService;
            
            RuleFor(x => x.EmpName).NotEmpty().WithName("Name");
            RuleFor(x => x).Must(EmployeeNotExist).WithName("EmpName").WithMessage("A employee with this name already exists. Use a different name.");
            RuleFor(x => x.Role).GreaterThan(0).WithMessage("Please select one of options below");
        }


        private bool EmployeeNotExist(EmployeeDto model)
        {
            var existingEmployees = _employeeService.GetByName(model.EmpName);
            if (!existingEmployees.Any())
            {
                return true;
            }
            if (_state == FormState.Edit)
            {
                var isCurrentEmployee = existingEmployees.Any(o => o.EmpId == (model.EmpId));
                if (isCurrentEmployee)
                {
                    return true;
                }

            }           
            return false;
        }
    }
}
