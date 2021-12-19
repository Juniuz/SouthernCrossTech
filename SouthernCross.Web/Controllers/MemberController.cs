using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SouthernCross.Web.Dto;
using SouthernCross.Web.Models;
using SouthernCross.Web.Services;

namespace SouthernCross.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly ILogger<MemberController> _logger;
        private readonly IMemberService _memberService;

        public MemberController(ILogger<MemberController> logger, IMemberService memberService)
        {
            _logger = logger;
            _memberService = memberService;
        }

        public IActionResult MemberSearch()
        {
            return View();
        }

        public IActionResult SearchResult()
        {
            return View();
        }

        [HttpGet("FindMember")]
        public async Task<IActionResult> FindMemberAsync(MemberIdentification memberIdentification)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _memberService.SearchMemberAsync(memberIdentification.PolicyNumber, memberIdentification.CardNumber));
            }

            const string message = "The provided member identification is invalid";

            _logger.LogError(message);
            return ValidationProblem(message);
        }

        [HttpGet("DisplayResult")]
        public async Task<IActionResult> DisplayResultAsync()
        {
            var memberViewModel = new MemberViewModel();
            return Ok(memberViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
