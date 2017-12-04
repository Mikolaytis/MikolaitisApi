using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Mikolaitis.Api.Authorization.Identity;
using Mikolaitis.Api.Authorization.Models;
using Mikolaitis.Api.Core.Models;

namespace Mikolaitis.Api.Authorization.Controllers
{
    public class AccountController : ApiController
    {
        [AllowAnonymous]
        public async Task<IHttpActionResult> RegisterUser(RegisterBindingModel registerData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser
            {
                UserName = registerData.Name,
                Email = registerData.Email,
                Password = registerData.Password
            };

            var manager = HttpContext.Current.GetOwinContext().GetUserManager<CustomUserManager>();
            var result = await manager.CreateAsync(user, user.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (result.Succeeded)
            {
                return null;
            }

            if (result.Errors != null)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            if (ModelState.IsValid)
            {
                return BadRequest();
            }

            return BadRequest(ModelState);
        }
    }
}
