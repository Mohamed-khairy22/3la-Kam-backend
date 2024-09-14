using _3la_Kam_backend.DTO;
using _3la_Kam_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        public async Task <IActionResult> login(LoginDTO userFromRequest)
        {
            if (ModelState.IsValid)
            {
                //check if valid
               ApplicationUser userFromDB= await userManager.FindByNameAsync(userFromRequest.userName);
                if (userFromDB != null)
                {
                   bool trusted= await userManager.CheckPasswordAsync(userFromDB, userFromRequest.password);
                    if (trusted)
                    {
                        //generate token steps
                        List<Claim> userClaims = new List<Claim>();

                        userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()));
                        userClaims.Add(new Claim(ClaimTypes.NameIdentifier, userFromDB.Id));
                        userClaims.Add(new Claim(ClaimTypes.Name,userFromDB.UserName));

                        var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("klsfdhgfsdf46s584sd5sdfasgegsdfgdsfdsgda@$#%^%#%@"));
                        var signingCred = new SigningCredentials(signInKey,SecurityAlgorithms.HmacSha256);

                        //design token
                        JwtSecurityToken myToken = new JwtSecurityToken(
                            audience: "http://localhost:4200/",
                            issuer: "http://localhost:5023/",
                            expires: DateTime.UtcNow.AddHours(1),
                            claims: userClaims,
                            signingCredentials: signingCred
                         );

                        //generating token
                        return Ok(
                            new
                            {
                                token = new JwtSecurityTokenHandler().WriteToken(myToken),
                                expiration = DateTime.UtcNow.AddHours(1) //myToken.ValidTo
                            }

                            );


                    }
                    return BadRequest("Password is not valid, try again");
                }
                return BadRequest("User not found");

            }
            return BadRequest(ModelState);
        }
    }
}
