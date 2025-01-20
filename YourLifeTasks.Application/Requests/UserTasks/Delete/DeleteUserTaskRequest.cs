using MediatR;

namespace YourLifeTasks.Application.Requests.UserTasks.Delete;

public record DeleteUserTaskRequest(
    Guid Id
) : IRequest;