using System.Diagnostics;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SouthernCross.Web.Dto;
using SouthernCross.Web.Models;
using SouthernCross.Web.Services;
using SouthernCross.Web.Validators;

namespace SouthernCross.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly ILogger<MemberController> _logger;
        private readonly IMemberService _memberService;

        public MemberController(ILogger<MemberController> logger, IMemberService memberService)
        {
            _memberService = memberService;
            _logger = logger;
        }

        public IActionResult MemberSearch()
        {
            return View();
        }

        public IActionResult SearchResult()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _memberService.FindAll());
        }

        [HttpGet("FindMember")]
        public async Task<IActionResult> FindMemberAsync(MemberIdentification memberIdentification)
        {
            if (ModelState.IsValid)
            {
                var memberIdentifcationValidator = new MemberIdentificationValidator();
                ValidationResult validator = await memberIdentifcationValidator.ValidateAsync(memberIdentification);

                if (validator.IsValid)
                {
                    return Ok(await _memberService.SearchMemberAsync(memberIdentification.PolicyNumber, memberIdentification.CardNumber));
                }
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
