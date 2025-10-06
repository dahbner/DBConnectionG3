using System.ComponentModel.DataAnnotations;

namespace DBConnectionG3.Models;

public class Event
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required, StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public DateTime Date { get; set; }

    [Range(1, 10000)]
    public int Capacity { get; set; }
}