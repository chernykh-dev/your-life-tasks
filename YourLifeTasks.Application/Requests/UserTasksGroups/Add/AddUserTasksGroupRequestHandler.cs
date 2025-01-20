using MediatR;
using YourLifeTasks.Domain.Entities;
using YourLifeTasks.Domain.Repositories;
using YourLifeTasks.Infrastructure.Db;

namespace YourLifeTasks.Application.Requests.UserTasksGroups.Add;

public class AddUserTasksGroupRequestHandler(IUserTasksGroupRepository userTasksGroupRepository, DbMediator dbMediator) : IRequestHandler<AddUserTasksGroupRequest, Guid>
{
    public async Task<Guid> Handle(AddUserTasksGroupRequest request, CancellationToken cancellationToken)
    {
        var userTasksGroup = new UserTasksGroup
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            CreatedAt = DateTimeOffset.UtcNow
        };

        await userTasksGroupRepository.Add(userTasksGroup);

        await dbMediator.SaveChanges(cancellationToken);

        return userTasksGroup.Id;
    }
}