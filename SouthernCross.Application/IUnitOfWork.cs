using System;
using SouthernCross.Persistence.Repositories;

namespace SouthernCross.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IMemberRepository Members { get; }
        void Commit();
    }
}
