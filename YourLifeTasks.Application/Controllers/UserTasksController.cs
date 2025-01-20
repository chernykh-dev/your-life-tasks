using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using YourLifeTasks.Application.Requests.UserTasks;
using YourLifeTasks.Application.Requests.UserTasks.Add;
using YourLifeTasks.Application.Requests.UserTasks.Delete;
using YourLifeTasks.Application.Requests.UserTasks.Get;
using YourLifeTasks.Application.Requests.UserTasks.GetAll;
using YourLifeTasks.Application.Requests.UserTasks.GetAllOnGroup;
using YourLifeTasks.Application.Requests.UserTasks.Move;
using YourLifeTasks.Application.Requests.UserTasksGroups.Update;
using YourLifeTasks.Domain.Entities;
using YourLifeTasks.Domain.Repositories;

namespace YourLifeTasks.Application.Controllers;

[ApiController]
[Route("/api/v1")]
public class UserTasksController(IMediator mediator) : ControllerBase
{
    [HttpGet("userTasks")]
    public async Task<ActionResult<UserTasksListResponse>> GetAll(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllUserTasksRequest(), cancellationToken);

        return Ok(result);
    }

    [HttpGet("userTasksGroups/{userTasksGroupId:guid}/userTasks")]
    public async Task<ActionResult<UserTasksListResponse>> GetAllOnGroup([FromRoute] Guid userTasksGroupId,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllUserTasksOnGroupRequest(userTasksGroupId), cancellationToken);

        return Ok(result);
    }

    [HttpGet("userTasks/{id:guid}")]
    public async Task<ActionResult<GetUserTaskResponse>> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetUserTaskRequest(id), cancellationToken);

        return Ok(result);
    }

    [HttpPost("userTasksGroups/{userTasksGroupId:guid}/userTasks")]
    public async Task<ActionResult<Guid>> Add([FromRoute] Guid userTasksGroupId, [FromBody] AddUserTaskRequest request,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request.WithUserTasksGroupId(userTasksGroupId), cancellationToken);

        return CreatedAtAction(nameof(Get), new { id = result }, result);
    }

    [HttpPut("userTasks/{id:guid}")]
    public async Task<ActionResult<Guid>> Update([FromRoute] Guid id, [FromBody] UpdateUserTasksGroupRequest request,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request.WithId(id), cancellationToken);

        return Ok(result);
    }

    [HttpPatch("userTasks/{id:guid}/move")]
    public async Task<ActionResult> Move([FromRoute] Guid id, [FromBody] MoveUserTaskRequest request,
        CancellationToken cancellationToken)
    {
        await mediator.Send(request.WithId(id), cancellationToken);

        return Ok();
    }

    [HttpDelete("userTasks/{id:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteUserTaskRequest(id), cancellationToken);

        return Ok();
    }
}