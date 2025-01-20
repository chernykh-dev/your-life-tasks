using AutoMapper;
using MediatR;
using YourLifeTasks.Domain.Entities;
using YourLifeTasks.Domain.Repositories;

namespace YourLifeTasks.Application.Requests.UserTasks.Get;

public class GetUserTaskRequestHandler(
    IUserTaskRepository userTaskRepository,
    IMapper mapper
) : IRequestHandler<GetUserTaskRequest, GetUserTaskResponse>
{
    public async Task<GetUserTaskResponse> Handle(GetUserTaskRequest request, CancellationToken cancellationToken)
    {
        var userTask = await userTaskRepository.GetWithGroupByIdReadOnly(request.Id);

        if (userTask == null)
        {
            throw new Exception("");
        }

        var result = mapper.Map<GetUserTaskResponse>(userTask);

        return result;
    }
}