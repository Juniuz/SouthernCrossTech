using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SouthernCross.Web.Dto;
using SouthernCross.Web.Models;

namespace SouthernCross.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly ILogger<MemberController> _logger;

        public MemberController(ILogger<MemberController> logger)
        {
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

        [HttpGet("FindMember")]
        public IActionResult FindMember(MemberIdentification memberIdentification)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem("The provided member identification is invalid");
            }

            return Ok();
        }

        [HttpGet("DisplayResult")]
        public IActionResult DisplayResult()
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
