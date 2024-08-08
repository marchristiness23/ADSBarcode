using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Model.Response;
using SHUNetMVC.Abstraction.Model.View;
using SHUNetMVC.Abstraction.Services;
using SHUNetMVC.Infrastructure.Services;
using SHUNetMVC.Infrastructure.Validators;

namespace SHUNetMVC.Web.Controllers
{
    public class DepartementController : BaseCrudController<DepartementDto, DepartementDto>
    {
        private IDepartementService _service;
        public DepartementController(IDepartementService crudSvc, ILookupService lookupSvc) : base(crudSvc, lookupSvc)
        {
            _service = crudSvc;
        }

        public override async Task<ActionResult> Create([Bind(Exclude = "")] DepartementDto model)
        {
            return await BaseCreate(model, new DepartementValidator(FormState.Create, _service));
        }

        public override async Task<ActionResult> Edit([Bind(Exclude = "")] DepartementDto model)
        {
            return await BaseUpdate(model, new DepartementValidator(FormState.Edit, _service));
        }


        protected override FormDefinition DefineForm(FormState formState)
        {
            return new FormDefinition
            {
                Title = "Departement",
                State = formState,
                FieldSections = new List<FieldSection>()
                {
                   new FieldSection
                    {
                        SectionName = "",
                        Fields = {
                                new Field {
                                Id = nameof(DepartementDto.DepartementId),
                                FieldType = FieldType.Hidden
                            },
                            new Field {
                                Id = nameof(DepartementDto.DepartementName),
                                Label = "Name",
                                FieldType = FieldType.Text,
                                IsRequired = true
                            }

                        }
                    }
                }
            };
        }

        protected override List<ColumnDefinition> DefineGrid()
        {
            return new List<ColumnDefinition>
            {
                new ColumnDefinition("Id", nameof(DepartementDto.DepartementId), ColumnType.Id),
                new ColumnDefinition("Name", nameof(DepartementDto.DepartementName), ColumnType.String),
            };
        }
    }
}
