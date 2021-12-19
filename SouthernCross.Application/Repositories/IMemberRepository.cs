using System.Collections.Generic;
using SouthernCross.Domain.Models;
using SouthernCross.Persistence.Generic;

namespace SouthernCross.Persistence.Repositories
{
    public interface IMemberRepository : IRepository<Member>
    {
        IEnumerable<Member> GetMembers(int policyNumber, int cardNumber);
        IEnumerable<Member> GetAllMembers();
    }
}
