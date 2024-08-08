using SHUNetMVC.Abstraction.Model.Dto;
using SHUNetMVC.Abstraction.Model.Entities;
using SHUNetMVC.Abstraction.Model.Response;
using SHUNetMVC.Abstraction.Model.View;
using SHUNetMVC.Abstraction.Repositories;
using SHUNetMVC.Infrastructure.EntityFramework.Queries;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace SHUNetMVC.Infrastructure.EntityFramework.Repositories
{
    public class EmployeeRepository : BaseCrudRepository<Employee, EmployeeDto, EmployeeWithDepartement, EmployeeQuery>, IEmployeeRepository
    {
        public EmployeeRepository(DB_PHE_ADSEntities context, IConnectionProvider connection)
            : base(context, connection, new EmployeeQuery())
        {
        }
        public override async Task Create(EmployeeDto model)
        {

            var entity = model.ToEntity();

            if (model.ProjectIds != null && model.ProjectIds.Any())
            {
                //entity.Projects = new List<Project>();
                //foreach (var projectId in model.ProjectIds)
                //{
                //    var project = _context.Projects.FirstOrDefault(o => o.ProjectId == projectId);
                //    entity.Projects.Add(project);
                //}
            }

            if (model.Educations != null && model.Educations.Any())
            {
                entity.EmployeeEducations = new List<EmployeeEducation>();
                foreach (var education in model.Educations)
                {
                    entity.EmployeeEducations.Add(new EmployeeEducation
                    {
                        School = education.School,
                        Degree = education.Degree,
                        EndDate = education.EndDate,
                        StartDate = education.StartDate,
                        FieldOfStudy = education.FieldOfStudy
                    });
                }
            }


            try
            {
                _context.Employees.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;
            }
         


        }

        public override async Task Update(EmployeeDto dto)
        {
            try
            {
                //var existing = _context.Employees.Find(dto.EmpId);

                var data = dto.ToEntity();
                _context.Employees.AddOrUpdate(data);
                await _context.SaveChangesAsync();

                // _context.Employees.Attach(data);
                var dataDb = _context.Employees.Find(dto.EmpId);

                // CLEAR,  ADD ALL
                _context.EmployeeEducations.RemoveRange(dataDb.EmployeeEducations);
                if (dto.Educations != null && dto.Educations.Any())
                {
                    foreach (var eduDto in dto.Educations)
                    {
                        var edu = eduDto.ToEntity();
                        edu.EmpId = dataDb.EmpId;
                        dataDb.EmployeeEducations.Add(edu);
                    }
                }
                await _context.SaveChangesAsync();

                // CLEAR, ADD ALL
                //dataDb.Projects.Clear();
                //if (dto.ProjectIds != null && dto.ProjectIds.Any())
                //{
                //    foreach (var projectId in dto.ProjectIds)
                //    {
                //        var project = _context.Projects.FirstOrDefault(o => o.ProjectId == projectId);
                //        dataDb.Projects.Add(project);
                //    }
                //}

              

                await _context.SaveChangesAsync();
            }
            catch (System.Exception e)
            {

                throw;
            }

        }

        public override async Task<EmployeeDto> GetOne(int id)
        {
            var entity = await _context.Employees.FindAsync(id);
            var dto = new EmployeeDto(entity);
            //dto.ProjectIds = entity.Projects.Select(o => o.ProjectId).ToList();
            dto.Educations = entity.EmployeeEducations.Select(o => new EmployeeEducationDto(o)).ToList();
            return dto;
        }


        public override async Task<LookupList> GetAdaptiveFilterList(string columnId)
        {
            var result = new LookupList
            {
                ColumnId = columnId
            };

            if (columnId == "DepartementName")
            {
                result.Items = _context.Employees.AsNoTracking()
                    .OrderBy(o => o.Departement.DepartementName)
                    .Select(o => new LookupItem
                    {
                        Value = o.Departement.DepartementName,
                        Text = o.Departement.DepartementName
                    }).Distinct().ToList();
            }
            else
            {
                using (var connection = OpenConnection())
                {
                    _context.Employees.Select(o => o.Departement.DepartementName);
                    var items = await connection.QueryAsync<string>($"SELECT DISTINCT {columnId} FROM dbo.Employee ORDER BY {columnId}");

                    result.Items = items.Select(item => new LookupItem
                    {
                        Text = item,
                        Value = item
                    }).ToList();
                }
            }


            result.Items = result.Items.GroupBy(o => o.Text).Select(o => o.FirstOrDefault()).ToList();

            return result;
        }

        public List<Employee> GetByName(string name)
        {
            return _context.Employees.Where(o => o.EmpName == name).ToList();
        }
    }
}
