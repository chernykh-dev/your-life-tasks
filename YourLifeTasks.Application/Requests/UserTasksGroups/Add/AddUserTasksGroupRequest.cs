using MediatR;

namespace YourLifeTasks.Application.Requests.UserTasksGroups.Add;

public record AddUserTasksGroupRequest(
    string Title,
    string? Description
) : IRequest<Guid>;