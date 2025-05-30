﻿using MediatR;
using YourLifeTasks.Domain.Repositories;

namespace YourLifeTasks.Application.Requests.UserTasks.GetAllOnGroup;

public class GetAllUserTasksOnGroupRequestHandler(
    IUserTasksGroupRepository userTasksGroupRepository,
    IUserTaskRepository userTaskRepository
) : IRequestHandler<GetAllUserTasksOnGroupRequest, UserTasksListResponse>
{
    public async Task<UserTasksListResponse> Handle(GetAllUserTasksOnGroupRequest request, CancellationToken cancellationToken)
    {
        /*
        var userTasksGroup = await userTasksGroupRepository.GetWithUserTasksByIdReadOnly(request.UserTasksGroupId);

        if (userTasksGroup == null)
        {
            throw new Exception("");
        }

        return new UserTasksListResponse(userTasksGroup.UserTasks);
        */

        var userTasks = await userTaskRepository.GetAllSortedByPriorityByGroupIdReadOnly(request.UserTasksGroupId);

        return new UserTasksListResponse(userTasks);
    }
}