namespace YourLifeTasks.Application.Requests.UserTasks.Get;

public record GetUserTaskResponse(
    Guid Id,
    string Title,
    string? Description,
    DateTimeOffset CreatedAt,
    Guid UserTasksGroupId
);