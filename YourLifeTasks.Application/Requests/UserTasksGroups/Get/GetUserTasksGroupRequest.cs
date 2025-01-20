using MediatR;
using YourLifeTasks.Domain.Entities;

namespace YourLifeTasks.Application.Requests.UserTasksGroups.Get;

public record GetUserTasksGroupRequest(Guid Id) : IRequest<UserTasksGroup>;