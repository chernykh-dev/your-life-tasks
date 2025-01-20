using YourLifeTasks.Domain.Entities;

namespace YourLifeTasks.Domain.Repositories;

public interface IUserTasksGroupRepository
{
    Task<List<UserTasksGroup>> GetAllReadOnly();

    Task<UserTasksGroup?> GetById(Guid id);

    Task<UserTasksGroup?> GetWithUserTasksByIdReadOnly(Guid id);

    Task Add(UserTasksGroup userTasksGroup);

    Task Delete(UserTasksGroup userTasksGroup);
}