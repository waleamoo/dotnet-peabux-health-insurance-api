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

            CreateMap<Staff, StaffGetDto>()
                .ForMember(dto => dto.StaffEmail, s => s.MapFrom(src => src.StaffEmail))
                .ForMember(dto => dto.StaffAddress, s => s.MapFrom(src => src.StaffAddress))
                .ForMember(dto => dto.StaffName, s => s.MapFrom(src => src.StaffName))
                .ForMember(dto => dto.StaffSurname, s => s.MapFrom(src => src.StaffSurname))
                .ForMember(dto => dto.StaffGuid, s => s.MapFrom(src => src.StaffGuid))
                .ForMember(dto => dto.CompanyId, s => s.MapFrom(src => src.Company.CompanyId))
                .ForMember(dto => dto.CompanyName, s => s.MapFrom(src => src.Company.CompanyName));
        }
    }
}
