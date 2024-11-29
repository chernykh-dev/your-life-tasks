using MediatR;
using Microsoft.AspNetCore.Mvc;
using YourLifeTasks.Application.Requests.UserTasks.Add;
using YourLifeTasks.Application.Requests.UserTasks.GetAll;

namespace YourLifeTasks.Application.Controllers;

[ApiController]
[Route("/api/v1/userTasks")]
public class UserTasksController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<GetAllUserTasksResponse> GetAll(CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetAllUserTasksRequest(), cancellationToken);
    }

    [HttpPost]
    public async Task<Guid> Add([FromBody] AddUserTaskRequest request, CancellationToken cancellationToken)
    {
        return await mediator.Send(request, cancellationToken);
    }
}