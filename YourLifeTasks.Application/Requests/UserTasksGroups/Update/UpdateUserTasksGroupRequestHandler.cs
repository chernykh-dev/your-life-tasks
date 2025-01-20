using MediatR;
using YourLifeTasks.Domain.Repositories;
using YourLifeTasks.Infrastructure.Db;

namespace YourLifeTasks.Application.Requests.UserTasksGroups.Update;

public class UpdateUserTasksGroupRequestHandler(IUserTasksGroupRepository userTasksGroupRepository, DbMediator dbMediator) : IRequestHandler<UpdateUserTasksGroupRequest, Guid>
{
    public async Task<Guid> Handle(UpdateUserTasksGroupRequest request, CancellationToken cancellationToken)
    {
        var userTasksGroup = await userTasksGroupRepository.GetById(request.Id);

        if (userTasksGroup == null)
        {
            throw new Exception("");
        }

        userTasksGroup.Update(request.Title, request.Description);

        await dbMediator.SaveChanges(cancellationToken);

        return userTasksGroup.Id;
    }
}