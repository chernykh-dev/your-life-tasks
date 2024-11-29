using MediatR;
using YourLifeTasks.Domain.Entities;
using YourLifeTasks.Domain.Repositories;

namespace YourLifeTasks.Application.Requests.UserTasks.Get;

public class GetUserTaskRequestHandler(IUserTaskRepository userTaskRepository)
    : IRequestHandler<GetUserTaskRequest, UserTask>
{
    public async Task<UserTask> Handle(GetUserTaskRequest request, CancellationToken cancellationToken)
    {
        // TODO: NotFoundException.
        var userTask = await userTaskRepository.GetById(request.Id);

        return userTask;
    }
}