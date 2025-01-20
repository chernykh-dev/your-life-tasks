using MediatR;
using YourLifeTasks.Domain.Repositories;
using YourLifeTasks.Infrastructure.Db;

namespace YourLifeTasks.Application.Requests.UserTasksGroups.Delete;

public class DeleteUserTasksGroupRequestHandler(IUserTasksGroupRepository userTasksGroupRepository, DbMediator dbMediator) : IRequestHandler<DeleteUserTasksGroupRequest>
{
    public async Task Handle(DeleteUserTasksGroupRequest request, CancellationToken cancellationToken)
    {
        var userTasksGroup = await userTasksGroupRepository.GetById(request.Id);

        if (userTasksGroup == null)
        {
            throw new Exception("");
        }

        await userTasksGroupRepository.Delete(userTasksGroup);

        await dbMediator.SaveChanges(cancellationToken);
    }
}