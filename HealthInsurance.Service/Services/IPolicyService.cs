using HealthInsurance.DataAccess.Dtos;

namespace HealthInsurance.Service.Services
{
    public interface IPolicyService
    {
        Task<MessageDto> AddPolicy();
    }
}