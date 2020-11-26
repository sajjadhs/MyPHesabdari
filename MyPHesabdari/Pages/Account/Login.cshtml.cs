using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyPHesabdari.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {

        [Required]
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        [Required]
        public string Password { get; set; }

        [BindProperty]
        public bool RememberMe { get; set; }


        [BindProperty]
        public string ReturnUrl { get; set; } = "/";
        public void OnGet(string returnUrl = "/")
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (Name == "sajjad" && Password == "1")
                {
                    List<Claim> claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, Name), new Claim(ClaimTypes.Name, Name), new Claim(ClaimTypes.Role, "User"), };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(claimsIdentity);
                    await this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = RememberMe });
                    return LocalRedirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Information is not correct!");
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnGetLogOutAsync()
        {
            if (User.Identity.IsAuthenticated)
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
        public ChallengeResult OnPostGoogleAsync()
        {
            var props = new AuthenticationProperties()
            {
                RedirectUri = Url.Action("Index", "Account"),
                Items =
                {
                    {"returnUrl",ReturnUrl }
                }
            };
            //return Challenge(props, GoogleDefaults.AuthenticationScheme);
            return Challenge(props, GoogleDefaults.AuthenticationScheme);





        }
    }
}
