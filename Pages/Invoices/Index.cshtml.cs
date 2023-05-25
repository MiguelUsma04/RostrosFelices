using Examen2.Data;
using Examen2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Examen2.Pages.Invoices
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly DataContext _context;
        public IndexModel(DataContext context)
        {
            _context = context;
        }

        public IList<Invoice> Invoices { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Invoices != null)
            {
                Invoices = await _context.Invoices.ToListAsync();
            }
        }
    }
}
