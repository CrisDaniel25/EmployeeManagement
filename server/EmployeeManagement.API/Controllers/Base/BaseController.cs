using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeManagement.API.Controllers.Base
{
    [Route("api/[controller]")]
    //[Authorize]
    public class BaseController : Controller
    {
        // UserId Claim
        protected int GetNameClaim()
        {

            var claim = User.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault();

            if (claim != null)
                return int.Parse(claim.Value);
            else
                return 0;

        }

        // Email Claim
        protected string GetEmailClaim()
        {

            var claim = User.Claims.Where(c => c.Type == ClaimTypes.Email).FirstOrDefault();

            if (claim != null)
                return claim.Value;
            else
                return string.Empty;

        }

        // Application Claim
        protected int GetApplicationClaim()
        {

            var claim = User.Claims.Where(c => c.Type == ClaimTypes.GroupSid).FirstOrDefault();

            if (claim != null)
                return int.Parse(claim.Value);
            else
                return 0;

        }

        protected void AddPagingHeader(int totalPages)
        {

            Response.Headers.Add("X-Total-Count", totalPages.ToString());
            Response.Headers.Add("Access-Control-Expose-Headers", "X-Total-Count");

        }

        protected IActionResult BadRequestError(String message)
        {
            return BadRequest(new { errorMessage = message });
        }

        protected IActionResult DefaultError(Exception ex)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                code = StatusCodes.Status500InternalServerError,
                error = ex.InnerException == null ? ex.Message : $"Message=>[  {ex.Message} ] InnerException=>[ {ex.InnerException.Message} ]"
            });

        }
    }
}
