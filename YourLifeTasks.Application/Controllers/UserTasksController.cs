using MediatR;
using Microsoft.AspNetCore.Mvc;
using YourLifeTasks.Application.Requests.UserTasks.Add;
using YourLifeTasks.Application.Requests.UserTasks.Get;
using YourLifeTasks.Application.Requests.UserTasks.GetAll;
using YourLifeTasks.Domain.Entities;

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

    [HttpGet("{Id:guid}")]
    public async Task<UserTask> Get([FromRoute] GetUserTaskRequest request, CancellationToken cancellationToken)
    {
        return await mediator.Send(request, cancellationToken);
    }

    [HttpPost]
    public async Task<Guid> Add([FromBody] AddUserTaskRequest request, CancellationToken cancellationToken)
    {
        return await mediator.Send(request, cancellationToken);
    }
}