using HealthInsurance.DataAccess.Models;

namespace HealthInsurance.DataAccess.Repository
{
    public interface ICompanyRepository
    {
        Task AddCompany(Company company);
        Task<Company?> GetCompany(int companyId);
    }
}