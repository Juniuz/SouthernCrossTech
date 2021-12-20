using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SouthernCross.Domain.Models;
using SouthernCross.Persistence;

namespace SouthernCross.Web.Services
{
    public class MemberService : IMemberService
    {
        private readonly ILogger<MemberService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public MemberService(ILogger<MemberService> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Member>> SearchMemberAsync(int policyNumber, int cardNumber)
        {
            _logger.LogDebug("{method} called with policy number[{policyNumber}] or member card number[{cardNumber}]", nameof(SearchMemberAsync), policyNumber,
                cardNumber);

            return await Task.FromResult(_unitOfWork.Members.GetMembers(policyNumber, cardNumber));
        }

        public async Task<IEnumerable<Member>> FindAll()
        {
            _logger.LogDebug("{method} called", nameof(FindAll));
            return await Task.FromResult(_unitOfWork.Members.GetAllMembers());
        }
    }
}
