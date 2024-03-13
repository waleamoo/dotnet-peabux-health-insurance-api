namespace HealthInsurance.DataAccess.Repository
{
    public interface IUnitOfWork
    {
        ICompanyRepository CompanyRepository { get; }

        Task<bool> SaveAsync();
    }
}