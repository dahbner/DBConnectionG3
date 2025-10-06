using System.ComponentModel.DataAnnotations;

namespace DBConnectionG3.Models.dtos;

public class UpdateEventDto
{
    [StringLength(100)]
    public string? Title { get; set; }
    public DateTime? Date { get; set; }
    [Range(1, 10000)]
    public int? Capacity { get; set; }
}