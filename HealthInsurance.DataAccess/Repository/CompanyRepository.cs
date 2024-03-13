using HealthInsurance.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsurance.DataAccess.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly HealthInsuranceContext context;

        public CompanyRepository(HealthInsuranceContext context)
        {
            this.context = context;
        }

        public async Task AddCompany(Company company)
        {
            company.CompanyGuid = Guid.NewGuid();
            company.CreatedDate = DateTime.UtcNow;
            company.ModifiedDate = DateTime.UtcNow;
            await context.Companies.AddAsync(company);
        }

        public async Task<Company?> GetCompany(int companyId)
        {
            return await context.Companies.FirstOrDefaultAsync(x => x.CompanyId == companyId);
        }
    }
}
