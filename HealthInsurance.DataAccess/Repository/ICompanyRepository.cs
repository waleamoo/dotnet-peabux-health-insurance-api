using HealthInsurance.DataAccess.Models;

namespace HealthInsurance.DataAccess.Repository
{
    public interface ICompanyRepository
    {
        void AddCompany(Company company);
    }
}