using Examen2.Data;
using Examen2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Examen2.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _context;
        public IndexModel(DataContext context)
        {
            _context = context;
        }

        public IList<Service> Services { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Services != null)
            {
                Services = await _context.Services.ToListAsync();
            }
        }
    }
}
