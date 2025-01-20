using MediatR;
using YourLifeTasks.Domain.Repositories;

namespace YourLifeTasks.Application.Requests.UserTasksGroups.GetAll;

public class GetAllUserTasksGroupsRequestHandler(IUserTasksGroupRepository userTasksGroupRepository) : IRequestHandler<GetAllUserTasksGroupsRequest, GetAllUserTasksGroupsResponse>
{
    public async Task<GetAllUserTasksGroupsResponse> Handle(GetAllUserTasksGroupsRequest request, CancellationToken cancellationToken)
    {
        var userTasksGroups = await userTasksGroupRepository.GetAllReadOnly();

        return new GetAllUserTasksGroupsResponse(userTasksGroups
            .Select(x => new SingleUserTasksGroup(x.Id, x.Title))
        );
    }
}