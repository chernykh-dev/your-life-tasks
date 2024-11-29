using MediatR;

namespace YourLifeTasks.Application.Requests.UserTasks.Add;

public record AddUserTaskRequest(
    string Description
) : IRequest<Guid>;