using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Model.View;
using SHUNetMVC.Abstraction.Services;
using FluentValidation;
using System.Linq;

namespace SHUNetMVC.Infrastructure.Validators
{
    public class DepartementValidator : AbstractValidator<DepartementDto>
    {
        private IDepartementService _departementService;
        private FormState _state;

        public DepartementValidator(FormState state, IDepartementService departementService)
        {
            _state = state;
            _departementService = departementService;
            
            RuleFor(x => x.DepartementName).NotEmpty().WithName("Name");
        }
    }
}
