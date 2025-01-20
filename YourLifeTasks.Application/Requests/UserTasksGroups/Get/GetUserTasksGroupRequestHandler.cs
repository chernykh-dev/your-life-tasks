using AutoMapper;
using MediatR;
using YourLifeTasks.Domain.Entities;
using YourLifeTasks.Domain.Repositories;

namespace YourLifeTasks.Application.Requests.UserTasksGroups.Get;

public class GetUserTasksGroupRequestHandler(IUserTasksGroupRepository userTasksGroupRepository, IMapper mapper) : IRequestHandler<GetUserTasksGroupRequest, UserTasksGroup>
{
    public async Task<UserTasksGroup> Handle(GetUserTasksGroupRequest request, CancellationToken cancellationToken)
    {
        var userTasksGroup = await userTasksGroupRepository.GetById(request.Id);

        if (userTasksGroup == null)
        {
            throw new Exception("");
        }

        return userTasksGroup;
    }
}