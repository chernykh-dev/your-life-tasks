using MediatR;

namespace YourLifeTasks.Application.Requests.UserTasksGroups.Delete;

public record DeleteUserTasksGroupRequest(Guid Id) : IRequest;