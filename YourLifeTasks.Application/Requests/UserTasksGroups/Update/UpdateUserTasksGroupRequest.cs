using System.Text.Json.Serialization;
using MediatR;

namespace YourLifeTasks.Application.Requests.UserTasksGroups.Update;

public record UpdateUserTasksGroupRequest(
    string Title,
    string? Description
) : IRequest<Guid>
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public UpdateUserTasksGroupRequest WithId(Guid id)
    {
        return this with { Id = id };
    }
}