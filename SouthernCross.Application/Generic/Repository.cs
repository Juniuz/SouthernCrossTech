using System;
using System.Linq.Expressions;
using LiteDB;
using SouthernCross.Data.Context;

namespace SouthernCross.Persistence.Generic
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly LiteDbContext _context;

        public Repository(LiteDbContext liteDbContext)
        {
            _context = liteDbContext;
        }

        public ILiteCollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Database.GetCollection<TEntity>().Find(predicate) as ILiteCollection<TEntity>;
        }

        public ILiteCollection<TEntity> GetAll()
        {
            return _context.Database.GetCollection<TEntity>();
        }
    }
}
