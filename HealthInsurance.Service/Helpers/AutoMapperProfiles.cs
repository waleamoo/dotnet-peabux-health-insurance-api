using HealthInsurance.DataAccess.Dtos;
using HealthInsurance.DataAccess.Models;
using AutoMapper;

namespace HealthInsurance.Service.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Company, CompanyAddDto>().ReverseMap();
        }
    }
}
