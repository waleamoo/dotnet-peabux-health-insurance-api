using HealthInsurance.DataAccess.Dtos;
using HealthInsurance.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsurance.DataAccess.Repository
{
    public interface IStaffRepository
    {
        Task<StaffGetDto?> GetStaff(Guid staffGuid, int? companyId);
        Task<List<StaffRoleType>> GetStaffRoleTypes();
    }
}
