namespace Examen2.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }

        public ICollection<Invoice>? Invoices { get; set; } = default!;
    }
}
