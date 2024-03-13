using HealthInsurance.DataAccess.Dtos;
using HealthInsurance.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsurance.DataAccess.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly HealthInsuranceContext context;

        public StaffRepository(HealthInsuranceContext context)
        {
            this.context = context;
        }

        public async Task AddStaff(Staff staff)
        {
            await context.Staff.AddAsync(staff);
        }

        public async Task AddStaffRole(int staffRoleTypeId, Guid staffGuid)
        {
            StaffRole staffRole = new StaffRole
            {
                StaffRoleTypeId = staffRoleTypeId,
                StaffGuid = staffGuid,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };
            await context.StaffRoles.AddAsync(staffRole);
        }
    }
}
