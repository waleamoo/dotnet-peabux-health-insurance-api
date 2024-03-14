using HealthInsurance.DataAccess.Dtos;
using HealthInsurance.DataAccess.Models;

namespace HealthInsurance.DataAccess.Repository
{
    public interface IUserRepository
    {
        Task<Staff> AuthenticateStaff(string staffEmail, string password);
        Task RegisterStaff(StaffAddDto staffAddDto);
        string CreatJWT(Staff staff);
        Task<bool> StaffAlreadyExists(string staffEmail);
    }
}
