using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3la_Kam_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost ("Register")]
        public IActionResult register()
        {

        }
        [HttpPost ("Login")]
        public IActionResult login()
        {

        }
    }
}
