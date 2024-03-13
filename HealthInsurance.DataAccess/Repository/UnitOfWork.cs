using AutoMapper;
using HealthInsurance.DataAccess.Models;

namespace HealthInsurance.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HealthInsuranceContext context;
        private readonly IMapper mapper;

        public UnitOfWork(HealthInsuranceContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ICompanyRepository CompanyRepository => new CompanyRepository(context);
        public IStaffRepository StaffRepository => new StaffRepository(context);

        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
