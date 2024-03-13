namespace HealthInsurance.DataAccess.Repository
{
    public interface IUnitOfWork
    {
        ICompanyRepository CompanyRepository { get; }
        IStaffRepository StaffRepository { get; }

        Task<bool> SaveAsync();
    }
}