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

            CreateMap<StaffAddDto, Staff>()
                .ForMember(d => d.StaffName, s => s.MapFrom(src => src.StaffName))
                .ForMember(d => d.StaffAddress, s => s.MapFrom(src => src.StaffAddress))
                .ForMember(d => d.StaffSurname, s => s.MapFrom(src => src.StaffSurname))
                .ForMember(d => d.StaffEmail, s => s.MapFrom(src => src.StaffEmail))
                .ForMember(d => d.CompanyId, s => s.MapFrom(src => src.CompanyId))
                .ForMember(d => d.CreatedDate, s => s.Ignore())
                .ForMember(d => d.ModifiedDate, s => s.Ignore())
                .ForMember(d => d.Password, s => s.Ignore())
                .ForMember(d => d.PasswordKey, s => s.Ignore()).ReverseMap();

            CreateMap<StaffGetDto, Staff>()
                .ForMember(d => d.StaffEmail, s => s.MapFrom(src => src.StaffEmail))
                .ForMember(d => d.StaffAddress, s => s.MapFrom(src => src.StaffAddress))
                .ForMember(d => d.StaffName, s => s.MapFrom(src => src.StaffName))
                .ForMember(d => d.StaffSurname, s => s.MapFrom(src => src.StaffSurname))
                .ForMember(d => d.StaffGuid, s => s.MapFrom(src => src.StaffGuid))
                .ForMember(d => d.CompanyId, s => s.MapFrom(src => src.CompanyId))
                .ForMember(d => d.Company, s => s.MapFrom(src => src.Company))
                .ForMember(d => d.CreatedDate, s => s.Ignore())
                .ForMember(d => d.ModifiedDate, s => s.Ignore())
                .ForMember(d => d.Password, s => s.Ignore())
                .ForMember(d => d.PasswordKey, s => s.Ignore()).ReverseMap();
        }
    }
}
