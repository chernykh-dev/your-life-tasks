using System.Text.Json.Serialization;
using MediatR;

namespace YourLifeTasks.Application.Requests.UserTasks.Update;

public record UpdateUserTaskRequest(
    string Title,
    string? Description,
    bool Completed,
    double Priority
) : IRequest<Guid>
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public UpdateUserTaskRequest WithId(Guid id)
    {
        return this with { Id = id };
    }
}