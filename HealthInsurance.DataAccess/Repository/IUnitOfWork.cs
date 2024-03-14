namespace HealthInsurance.DataAccess.Repository
{
    public interface IUnitOfWork
    {
        ICompanyRepository CompanyRepository { get; }
        IUserRepository UserRepository { get; }
        IStaffRepository StaffRepository { get; }
        Task<bool> SaveAsync();
    }
}