using Examen2.Data;
using Examen2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Examen2.Pages.Services
{
    public class DeleteModel : PageModel
    {
        private readonly DataContext _context;
        public DeleteModel(DataContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Service Service { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }
            var detail = await _context.Services.FirstOrDefaultAsync(m => m.Id == id);

            if (detail == null)
            {
                return NotFound();
            }
            else
            {
                Service = detail;
            }
            return Page();

        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }
            var detail = await _context.Services.FindAsync(id);

            if (detail != null)
            {
                Service = detail;
                _context.Services.Remove(Service);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }


    }
}
