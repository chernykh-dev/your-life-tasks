﻿using YourLifeTasks.Domain.Entities;

namespace YourLifeTasks.Domain.Repositories;

public interface IUserTaskRepository
{
    Task<List<UserTask>> GetAllReadOnly();

    Task<UserTask?> GetById(Guid id);

    Task<UserTask?> GetWithGroupByIdReadOnly(Guid id);

    Task<List<UserTask>> GetAllSortedByPriorityByGroupIdReadOnly(Guid groupId);

    Task Add(UserTask userTask);

    Task Delete(UserTask userTask);
}