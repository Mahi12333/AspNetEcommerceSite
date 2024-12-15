namespace EcommerceProject.Repositories.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationUserRepository ApplicationUserRepository { get; }
        IOtpRepository OtpRepository { get; }
        Task CompleteAsync();// both are same 
        //Task SaveAsync(); // 
        void Save();
    }

}
