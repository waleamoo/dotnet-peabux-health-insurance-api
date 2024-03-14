using AutoMapper;
using HealthInsurance.DataAccess.Dtos;
using HealthInsurance.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthInsurance.DataAccess.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly HealthInsuranceContext context;
        private readonly IMapper mapper;

        public StaffRepository(HealthInsuranceContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<StaffGetDto?> GetStaff(Guid staffGuid, int? companyId)
        {
            if (companyId != null)
            {
                return mapper.Map<StaffGetDto>(await context.Staff.Include(x => x.Company).FirstOrDefaultAsync(x => x.StaffGuid ==  staffGuid));
            }
            return mapper.Map<StaffGetDto>(await context.Staff.FirstOrDefaultAsync(x => x.StaffGuid == staffGuid));
        }

        public async Task<List<StaffRoleType>> GetStaffRoleTypes()
        {
            return await context.StaffRoleTypes.ToListAsync();
        }
    }
}
