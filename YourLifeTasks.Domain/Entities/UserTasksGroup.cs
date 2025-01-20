using System.Text.Json.Serialization;

namespace YourLifeTasks.Domain.Entities;

public class UserTasksGroup
{
    public required Guid Id { get; set; }

    public required string Title { get; set; }

    public string? Description { get; set; }

    public required DateTimeOffset CreatedAt { get; set; }

    [JsonIgnore]
    public virtual List<UserTask> UserTasks { get; set; }

    public void Update(string title, string? description)
    {
        Title = title;
        Description = description;
    }
}