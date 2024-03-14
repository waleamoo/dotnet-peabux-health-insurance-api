using AutoMapper;
using HealthInsurance.DataAccess.Models;
using Microsoft.Extensions.Configuration;

namespace HealthInsurance.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HealthInsuranceContext context;
        private readonly IMapper mapper;
        private readonly IConfiguration config;

        public UnitOfWork(HealthInsuranceContext context, IMapper mapper, IConfiguration config)
        {
            this.context = context;
            this.mapper = mapper;
            this.config = config;
        }

        public ICompanyRepository CompanyRepository => new CompanyRepository(context);
        public IUserRepository UserRepository => new UserRepository(context, mapper, config);
        public IStaffRepository StaffRepository => new StaffRepository(context, mapper);


        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
