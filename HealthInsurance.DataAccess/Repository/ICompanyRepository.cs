using HealthInsurance.DataAccess.Models;

namespace HealthInsurance.DataAccess.Repository
{
    public interface ICompanyRepository
    {
        void AddCity(Company company);
    }
}