using MediatR;
using YourLifeTasks.Domain.Repositories;
using YourLifeTasks.Infrastructure.Db;

namespace YourLifeTasks.Application.Requests.UserTasks.Update;

public class UpdateUserTaskRequestHandler(IUserTaskRepository userTaskRepository, DbMediator dbMediator) : IRequestHandler<UpdateUserTaskRequest, Guid>
{
    public async Task<Guid> Handle(UpdateUserTaskRequest request, CancellationToken cancellationToken)
    {
        var userTask = await userTaskRepository.GetById(request.Id);

        if (userTask == null)
        {
            throw new Exception("User task not found");
        }

        userTask.Update(request.Title, request.Description, request.Completed, request.Priority);

        await dbMediator.SaveChanges(cancellationToken);

        return userTask.Id;
    }
}