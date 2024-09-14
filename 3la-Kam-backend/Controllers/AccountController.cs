using _3la_Kam_backend.DTO;
using _3la_Kam_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _3la_Kam_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> userManager;

        public AccountController(UserManager<ApplicationUser> UserManager)
        {
            userManager = UserManager;
        }
        [HttpPost ("Register")]
        public async Task <IActionResult> register(RegisterDTO userFromRequest)
        {
            if(ModelState.IsValid)
            {
                //save in DB
                ApplicationUser user = new ApplicationUser();
                user.UserName = userFromRequest.userName;
                user.Email = userFromRequest.email;
                IdentityResult result =
              await userManager.CreateAsync(user, userFromRequest.password);
                if (result.Succeeded)
                {
                    return Ok("Created successfully");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("Password" , item.Description);
                }
            }
            return BadRequest(ModelState);

        }
        [HttpPost ("Login")]
        public IActionResult login()
        {
            return Ok();
        }
    }
}
