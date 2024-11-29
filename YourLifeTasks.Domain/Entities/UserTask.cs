namespace YourLifeTasks.Domain.Entities;

public class UserTask
{
    public required Guid Id { get; set; }

    public required string Description { get; set; } = null!;

    public required DateTimeOffset CreatedAt { get; set; }
}