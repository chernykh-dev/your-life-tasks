using MediatR;
using YourLifeTasks.Domain.Entities;

namespace YourLifeTasks.Application.Requests.UserTasks.Get;

public record GetUserTaskRequest(
    Guid Id
) : IRequest<GetUserTaskResponse>;