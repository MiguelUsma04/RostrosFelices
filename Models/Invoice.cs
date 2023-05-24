using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Examen2.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public ICollection<Employee>? Employees { get; set; } = default!;
    }
}
