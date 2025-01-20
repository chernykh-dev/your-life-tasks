using System.Text.Json.Serialization;
using MediatR;

namespace YourLifeTasks.Application.Requests.UserTasks.Move;

public record MoveUserTaskRequest(Guid UserTasksGroupId) : IRequest
{
    [JsonIgnore]
    public Guid Id { get; private init; }

    public MoveUserTaskRequest WithId(Guid id)
    {
        return this with { Id = id };
    }
}