namespace First.DTOs;

public sealed class TodoDto
{
    public string Work { get; set; } = string.Empty;
    public string StartDate { get; set; }
}

public sealed class AddTodoDto
{
    public string Work { get; set; } = string.Empty;
    public string StartDate { get; set; }
}

public sealed class UpdateTodoDto
{
    public int Id { get; set; }
    public string Work { get; set; } = string.Empty;
    public string StartDate { get; set; }
}
