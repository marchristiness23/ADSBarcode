using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Model.View;
using SHUNetMVC.Abstraction.Services;
using FluentValidation;
using System.Linq;

namespace SHUNetMVC.Infrastructure.Validators
{
    public class WorkerValidator : AbstractValidator<WorkerDto>
    {
        private IWorkerService _workerService;
        private FormState _state;

        public WorkerValidator(FormState state, IWorkerService workerService)
        {
            _state = state;
            _workerService = workerService;
            
            RuleFor(x => x.FirstName).NotEmpty().WithName("First Name");
            RuleFor(x => x.LastName).NotEmpty().WithName("Last Name");
        }
    }
}
