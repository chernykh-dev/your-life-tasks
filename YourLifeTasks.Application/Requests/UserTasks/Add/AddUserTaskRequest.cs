using System.Text.Json.Serialization;
using MediatR;
using YourLifeTasks.Domain.Entities;

namespace YourLifeTasks.Application.Requests.UserTasks.Add;

public record AddUserTaskRequest(
    string Title,
    string? Description
) : IRequest<Guid>
{
    [JsonIgnore]
    public Guid UserTasksGroupId { get; private init; }

    public AddUserTaskRequest WithUserTasksGroupId(Guid userTasksGroupId)
    {
        return this with { UserTasksGroupId = userTasksGroupId };
    }
}