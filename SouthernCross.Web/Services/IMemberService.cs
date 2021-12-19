using System.Collections.Generic;
using System.Threading.Tasks;
using SouthernCross.Domain.Models;

namespace SouthernCross.Web.Services
{
    public interface IMemberService
    {
        Task<IEnumerable<Member>> SearchMemberAsync(int policyNumber, int cardNumber);
        Task<IEnumerable<Member>> FindAll();
    }
}
