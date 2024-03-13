using HealthInsurance.DataAccess.Models;
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

        public void AddCity(Company company)
        {
            context.Companies.AddAsync(company);
        }
    }
}
