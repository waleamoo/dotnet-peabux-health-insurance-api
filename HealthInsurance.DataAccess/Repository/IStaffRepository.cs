using HealthInsurance.DataAccess.Models;

namespace HealthInsurance.DataAccess.Repository
{
    public interface IStaffRepository
    {
        Task AddStaff(Staff staff);
        Task AddStaffRole(int staffRoleTypeId, Guid staffGuid);
    }
}