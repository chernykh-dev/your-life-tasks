using MediatR;
using Microsoft.AspNetCore.Mvc;
using YourLifeTasks.Application.Requests.UserTasksGroups.Add;
using YourLifeTasks.Application.Requests.UserTasksGroups.Delete;
using YourLifeTasks.Application.Requests.UserTasksGroups.Get;
using YourLifeTasks.Application.Requests.UserTasksGroups.GetAll;
using YourLifeTasks.Application.Requests.UserTasksGroups.Update;
using YourLifeTasks.Domain.Entities;

namespace YourLifeTasks.Application.Controllers;

[ApiController]
[Route("/api/v1/userTasksGroups")]
public class UserTasksGroupsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetAllUserTasksGroupsResponse>> GetAll(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllUserTasksGroupsRequest(), cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserTasksGroup>> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetUserTasksGroupRequest(id), cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Add([FromBody] AddUserTasksGroupRequest request,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);

        return CreatedAtAction(nameof(Get), new { id = result }, result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> Update([FromRoute] Guid id, [FromBody] UpdateUserTasksGroupRequest request,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request.WithId(id), cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteUserTasksGroupRequest(id), cancellationToken);

        return Ok();
    }
}