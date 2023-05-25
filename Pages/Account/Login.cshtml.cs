using Examen2.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Examen2.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        private readonly SupermarketContext _context;

        public LoginModel(SupermarketContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var findUser = await _context.Users
                .Where(x => x.Email == User.Email && x.Password == User.Password)
                .FirstOrDefaultAsync();

            if (findUser != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, User.Email),

                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                return RedirectToPage("../Index");
            }
            else
            {
                Redirect("/Login");
            }
            return Page();
        }
    }
}
