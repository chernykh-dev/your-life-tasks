using MediatR;
using YourLifeTasks.Domain.Repositories;
using YourLifeTasks.Infrastructure.Db;

namespace YourLifeTasks.Application.Requests.UserTasks.Move;

public class MoveUserTaskRequestHandler(IUserTaskRepository userTaskRepository, IUserTasksGroupRepository userTasksGroupRepository, DbMediator dbMediator) : IRequestHandler<MoveUserTaskRequest>
{
    public async Task Handle(MoveUserTaskRequest request, CancellationToken cancellationToken)
    {
        var userTask = await userTaskRepository.GetById(request.Id);

        if (userTask == null)
        {
            throw new Exception("");
        }

        var userTasksGroup = await userTasksGroupRepository.GetById(request.UserTasksGroupId);

        if (userTasksGroup == null)
        {
            throw new Exception("");
        }

        userTask.UserTasksGroup = userTasksGroup;

        await dbMediator.SaveChanges(cancellationToken);
    }
}