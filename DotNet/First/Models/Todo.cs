using System.ComponentModel.DataAnnotations;

namespace First.Models;

public sealed class Todo
{
    [Key]
    public int Id { get; set; }
    public string Work { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public bool IsCompleted { get; set; } = false;
}
