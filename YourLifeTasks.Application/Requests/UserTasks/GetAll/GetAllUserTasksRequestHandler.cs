using MediatR;
using YourLifeTasks.Domain.Repositories;

namespace YourLifeTasks.Application.Requests.UserTasks.GetAll;

public class GetAllUserTasksRequestHandler(IUserTaskRepository userTaskRepository) : IRequestHandler<GetAllUserTasksRequest, GetAllUserTasksResponse>
{
    public async Task<GetAllUserTasksResponse> Handle(GetAllUserTasksRequest request, CancellationToken cancellationToken)
    {
        var entities = await userTaskRepository.GetAllReadOnly();

        var result = new GetAllUserTasksResponse(entities.Count, entities);

        return result;
    }
}