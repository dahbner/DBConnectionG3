using System.ComponentModel.DataAnnotations;

namespace DBConnectionG3.Models.dtos
{
    public record CreateGuestDto
    {
        [Required, StringLength(200)]
        public string FullName { get; set; } = string.Empty;

        public bool Confirmed { get; set; } = false; 
    }
}