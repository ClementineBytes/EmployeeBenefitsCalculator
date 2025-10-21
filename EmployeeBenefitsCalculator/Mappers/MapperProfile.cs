using AutoMapper;
using Models.DTO;
using Models.Employees;
using Models.Payroll;

namespace EmployeeBenefitsCalculator.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<EmployeeDTO, Employee>().ReverseMap();
            CreateMap<BenefitDTO, Benefit>().ReverseMap();
        }
    }
}
