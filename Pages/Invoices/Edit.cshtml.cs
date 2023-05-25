using Examen2.Data;
using Examen2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Examen2.Pages.Invoices
{
    public class EditModel : PageModel
    {
        private readonly DataContext _context;
        public EditModel(DataContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Invoice Invoice { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Invoices == null)
            {
                return NotFound();
            }
            var detail = await _context.Invoices.FirstOrDefaultAsync(m => m.Id == id);

            if (detail == null)
            {
                return NotFound();
            }

            Invoice = detail;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(Invoice.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return RedirectToPage("./Index");
        }
        private bool InvoiceExists(int id)
        {
            return (_context.Invoices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
