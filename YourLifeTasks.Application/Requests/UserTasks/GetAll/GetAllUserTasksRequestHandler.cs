using MediatR;
using YourLifeTasks.Domain.Repositories;

namespace YourLifeTasks.Application.Requests.UserTasks.GetAll;

public class GetAllUserTasksRequestHandler(IUserTaskRepository userTaskRepository) : IRequestHandler<GetAllUserTasksRequest, UserTasksListResponse>
{
    public async Task<UserTasksListResponse> Handle(GetAllUserTasksRequest request, CancellationToken cancellationToken)
    {
        var entities = await userTaskRepository.GetAllReadOnly();

        return new UserTasksListResponse(entities);
    }
}