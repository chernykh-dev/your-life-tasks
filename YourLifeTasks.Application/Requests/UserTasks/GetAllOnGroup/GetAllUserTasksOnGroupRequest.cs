using MediatR;

namespace YourLifeTasks.Application.Requests.UserTasks.GetAllOnGroup;

public record GetAllUserTasksOnGroupRequest(
    Guid UserTasksGroupId
) : IRequest<UserTasksListResponse>;