using MediatR;
using YourLifeTasks.Domain.Entities;
using YourLifeTasks.Domain.Repositories;
using YourLifeTasks.Infrastructure.Db;

namespace YourLifeTasks.Application.Requests.UserTasks.Add;

public class AddUserTaskRequestHandler(IUserTaskRepository userTaskRepository, DbMedator dbMedator) : IRequestHandler<AddUserTaskRequest, Guid>
{
    public async Task<Guid> Handle(AddUserTaskRequest request, CancellationToken cancellationToken)
    {
        var userTask = new UserTask
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            CreatedAt = DateTimeOffset.UtcNow
        };

        userTaskRepository.Add(userTask);

        await dbMedator.SaveChanges(cancellationToken);

        return userTask.Id;
    }
}