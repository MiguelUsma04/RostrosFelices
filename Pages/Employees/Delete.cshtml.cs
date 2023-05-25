using Examen2.Data;
using Examen2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Examen2.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly DataContext _context;
        public DeleteModel(DataContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }
            var detail = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);

            if (detail == null)
            {
                return NotFound();
            }
            else
            {
                Employee = detail;
            }
            return Page();

        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }
            var detail = await _context.Employees.FindAsync(id);

            if (detail != null)
            {
                Employee = detail;
                _context.Employees.Remove(Employee);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }


    }
}
