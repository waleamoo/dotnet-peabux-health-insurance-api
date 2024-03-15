using HealthInsurance.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsurance.DataAccess.Repository
{
    public interface IPolicyRepository
    {
        Task AddPolicy(PolicyAddDto policyAddDto);
    }
}
