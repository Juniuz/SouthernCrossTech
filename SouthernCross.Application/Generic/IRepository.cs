using System;
using System.Linq.Expressions;
using LiteDB;

namespace SouthernCross.Persistence.Generic
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ILiteCollection<TEntity> GetAll();
        ILiteCollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
