using Examen2.Data;
using Examen2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Examen2.Pages.Clients
{
    public class DeleteModel : PageModel
    {
        private readonly DataContext _context;
        public DeleteModel(DataContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Client Client { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }
            var detail = await _context.Clients.FirstOrDefaultAsync(m => m.Id == id);

            if (detail == null)
            {
                return NotFound();
            }
            else
            {
                Client = detail;
            }
            return Page();

        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }
            var detail = await _context.Clients.FindAsync(id);

            if (detail != null)
            {
                Client = detail;
                _context.Clients.Remove(Client);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }


    }
}
