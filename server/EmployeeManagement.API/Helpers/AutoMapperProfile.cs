using AutoMapper;
using EmployeeManagement.API.Dtos.Employees;
using EmployeeManagement.Domain.Entities.Employees;

namespace EmployeeManagement.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();

            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>();

            CreateMap<Position, PositionDto>();
            CreateMap<PositionDto, Position>();
        }
    }
}
