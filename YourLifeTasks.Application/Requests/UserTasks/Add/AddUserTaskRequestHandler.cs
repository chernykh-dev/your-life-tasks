using MediatR;
using YourLifeTasks.Domain.Entities;
using YourLifeTasks.Domain.Repositories;
using YourLifeTasks.Infrastructure.Db;

namespace YourLifeTasks.Application.Requests.UserTasks.Add;

public class AddUserTaskRequestHandler(
    IUserTaskRepository userTaskRepository,
    IUserTasksGroupRepository userTasksGroupRepository,
    DbMediator dbMediator
) : IRequestHandler<AddUserTaskRequest, Guid>
{
    public async Task<Guid> Handle(AddUserTaskRequest request, CancellationToken cancellationToken)
    {
        var userTasksGroup = await userTasksGroupRepository.GetById(request.UserTasksGroupId);

        if (userTasksGroup == null)
        {
            throw new Exception("");
        }

        var userTask = new UserTask
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            CreatedAt = DateTimeOffset.UtcNow,
            UserTasksGroup = userTasksGroup
        };

        await userTaskRepository.Add(userTask);

        await dbMediator.SaveChanges(cancellationToken);

        return userTask.Id;
    }
}