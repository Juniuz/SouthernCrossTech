using SouthernCross.Data.Context;
using SouthernCross.Persistence.Repositories;

namespace SouthernCross.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LiteDbContext _dbContext;

        public UnitOfWork(LiteDbContext dbContext)
        {
            _dbContext = dbContext;
            Members = new MemberRepository(_dbContext);
        }

        public IMemberRepository Members { get; }

        public void Dispose()
        {
            _dbContext.Database.Dispose();
        }

        public void Commit()
        {
            _dbContext.Database.Commit();
        }
    }
}
