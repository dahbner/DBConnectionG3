using System.ComponentModel.DataAnnotations;

namespace DBConnectionG3.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public bool Confirmed { get; set; } = false;
    }
}