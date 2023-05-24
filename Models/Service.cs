namespace Examen2.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Invoice>? Invoices { get; set; } = default!;
    }
}
