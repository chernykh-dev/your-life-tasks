using MediatR;
using YourLifeTasks.Domain.Repositories;
using YourLifeTasks.Infrastructure.Db;

namespace YourLifeTasks.Application.Requests.UserTasks.Delete;

public class DeleteUserTaskRequestHandler(IUserTasksGroupRepository userTasksGroupRepository, IUserTaskRepository userTaskRepository, DbMediator dbMediator) : IRequestHandler<DeleteUserTaskRequest>
{
    public async Task Handle(DeleteUserTaskRequest request, CancellationToken cancellationToken)
    {
        var userTask = await userTaskRepository.GetById(request.Id);

        if (userTask == null)
        {
            throw new Exception("");
        }

        await userTaskRepository.Delete(userTask);

        await dbMediator.SaveChanges(cancellationToken);
    }
}