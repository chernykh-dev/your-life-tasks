using YourLifeTasks.Domain.Entities;

namespace YourLifeTasks.Application.Requests.UserTasks.GetAll;

public record GetAllUserTasksResponse(
    int Total,
    List<UserTask> Data
);