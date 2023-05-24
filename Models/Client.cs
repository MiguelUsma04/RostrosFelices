namespace Examen2.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Document_Number { get; set; }

        public ICollection<Invoice>? Products { get; set; } = default!;

    }
}
