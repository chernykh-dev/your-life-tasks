using MediatR;

namespace YourLifeTasks.Application.Requests.UserTasksGroups.GetAll;

public record GetAllUserTasksGroupsRequest : IRequest<GetAllUserTasksGroupsResponse>;