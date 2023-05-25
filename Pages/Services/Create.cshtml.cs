using Examen2.Data;
using Examen2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Examen2.Pages.Services
{
    public class CreateModel : PageModel
    {
        private readonly DataContext _context;
        public CreateModel(DataContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]

        public Service Service { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Services == null || Service == null)
            {
                return Page();
            }
            _context.Services.Add(Service);
            await _context.SaveChangesAsync();

            return RedirectToAction("./Index");
        }
    }
}
