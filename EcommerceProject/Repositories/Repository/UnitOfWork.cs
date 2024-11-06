using EcommerceProject.Repositories.Repository.IRepository;
using System.Threading.Tasks;

namespace EcommerceProject.Repositories.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IApplicationUserRepository ApplicationUserRepository { get; private set; }
        public IOtpRepository OtpRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            ApplicationUserRepository = new ApplicationUserRepository(_dbContext);
            OtpRepository = new OtpRepository(_dbContext);
        }

        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
