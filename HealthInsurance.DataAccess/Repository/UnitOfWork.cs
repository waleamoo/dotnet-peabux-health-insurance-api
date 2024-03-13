using AutoMapper;
using HealthInsurance.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
