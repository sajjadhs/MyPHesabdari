using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPHesabdari.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var res = await HttpContext.AuthenticateAsync("ExternalGoogleAuthentication");
                return Json(res);
            }
            catch {
                return Content("error");
            }
        }
    }
}
