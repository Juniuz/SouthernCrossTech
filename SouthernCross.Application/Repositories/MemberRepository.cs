using System.Collections.Generic;
using SouthernCross.Data.Context;
using SouthernCross.Domain.Models;
using SouthernCross.Persistence.Generic;

namespace SouthernCross.Persistence.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        private readonly LiteDbContext _liteDbContext;

        public MemberRepository(LiteDbContext liteDbContext) : base(liteDbContext)
        {
            _liteDbContext = liteDbContext;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _liteDbContext.Database.GetCollection<Member>("Member").FindAll();
        }

        public IEnumerable<Member> GetMembers(int policyNumber, int cardNumber)
        {
            return _liteDbContext.Database.GetCollection<Member>("Member").Find(m => m.PolicyNumber == policyNumber || m.CardNumber == cardNumber);
        }
    }
}
