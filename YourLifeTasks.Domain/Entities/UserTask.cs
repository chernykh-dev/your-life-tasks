using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace YourLifeTasks.Domain.Entities;

public class UserTask
{
    public required Guid Id { get; set; }

    public required string Title { get; set; } = null!;

    public string? Description { get; set; }

    public bool Completed { get; set; } = false;

    public required DateTimeOffset CreatedAt { get; set; }

    public required double Priority { get; set; }

    public required Guid? ParentUserTaskId { get; set; }

    [JsonIgnore]
    public virtual UserTasksGroup UserTasksGroup { get; set; }

    [JsonIgnore]
    [ForeignKey("ParentUserTaskId")]
    public virtual UserTask? ParentUserTask { get; set; }

    public virtual List<UserTask> ChildUserTasks { get; set; }

    public void Update(string title, string? description, bool completed, double priority)
    {
        Title = title;
        Description = description;
        Completed = completed;
        Priority = priority;
    }
}