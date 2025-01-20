using Microsoft.EntityFrameworkCore;
using YourLifeTasks.Domain.Entities;
using YourLifeTasks.Domain.Repositories;
using YourLifeTasks.Infrastructure.Db;

namespace YourLifeTasks.Infrastructure.Repositories;

public class UserTaskGroupRepository(TasksDbContext tasksDbContext) : IUserTasksGroupRepository
{
    public async Task<List<UserTasksGroup>> GetAllReadOnly()
    {
        var entities = await tasksDbContext
            .UserTasksGroups
            .AsNoTracking()
            .ToListAsync();

        return entities;
    }

    public async Task<UserTasksGroup?> GetById(Guid id)
    {
        var entity = await tasksDbContext
            .UserTasksGroups
            .FirstOrDefaultAsync(x => x.Id == id);

        return entity;
    }

    public async Task<UserTasksGroup?> GetWithUserTasksByIdReadOnly(Guid id)
    {
        var entity = await tasksDbContext
            .UserTasksGroups
            .Include(x => x.UserTasks)
            .Where(x => x.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return entity;
    }

    public async Task Add(UserTasksGroup userTasksGroup)
    {
        await tasksDbContext.UserTasksGroups.AddAsync(userTasksGroup);
    }

    public async Task Delete(UserTasksGroup userTasksGroup)
    {
        tasksDbContext.UserTasksGroups.Remove(userTasksGroup);
    }
}