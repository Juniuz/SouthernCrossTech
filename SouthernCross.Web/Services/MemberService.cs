using System.Collections.Generic;
using System.Threading.Tasks;
using SouthernCross.Domain.Models;
using SouthernCross.Persistence;

namespace SouthernCross.Web.Services
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Member>> SearchMemberAsync(int policyNumber, int cardNumber)
        {
            return await Task.FromResult(_unitOfWork.Members.GetMembers(policyNumber, cardNumber));
        }

        public async Task<IEnumerable<Member>> FindAll()
        {
            return await Task.FromResult(_unitOfWork.Members.GetAllMembers());
        }
    }
}
