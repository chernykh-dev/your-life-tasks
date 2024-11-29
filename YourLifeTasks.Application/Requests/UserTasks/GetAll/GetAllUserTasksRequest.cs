using MediatR;

namespace YourLifeTasks.Application.Requests.UserTasks.GetAll;

public record GetAllUserTasksRequest : IRequest<GetAllUserTasksResponse>;