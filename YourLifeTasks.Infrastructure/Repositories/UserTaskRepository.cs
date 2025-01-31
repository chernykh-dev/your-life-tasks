using Microsoft.EntityFrameworkCore;
using YourLifeTasks.Domain.Entities;
using YourLifeTasks.Domain.Repositories;
using YourLifeTasks.Infrastructure.Db;

namespace YourLifeTasks.Infrastructure.Repositories;

public class UserTaskRepository(TasksDbContext dbContext) : IUserTaskRepository
{
    public async Task<List<UserTask>> GetAllReadOnly()
    {
        var entities = await dbContext
            .UserTasks
            .AsNoTracking()
            .ToListAsync();

        return entities;
    }

    public async Task<UserTask?> GetById(Guid id)
    {
        var entity = await dbContext
            .UserTasks
            .FirstOrDefaultAsync(x => x.Id == id);

        return entity;
    }

    public async Task<UserTask?> GetWithGroupByIdReadOnly(Guid id)
    {
        var entity = await dbContext
            .UserTasks
            .Include(x => x.UserTasksGroup)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return entity;
    }

    public async Task<List<UserTask>> GetAllSortedByPriorityByGroupIdReadOnly(Guid groupId)
    {
        var entities = await dbContext
            .UserTasks
            .Include(x => x.UserTasksGroup)
            .Where(x => x.UserTasksGroup.Id == groupId)
            .OrderBy(x => !x.Completed)
            .ThenBy(x => x.Priority)
            .AsNoTracking()
            .ToListAsync();

        return entities;
    }


    public async Task Add(UserTask userTask)
    {
        await dbContext.UserTasks.AddAsync(userTask);
    }

    public async Task Delete(UserTask userTask)
    {
        dbContext.UserTasks.Remove(userTask);
    }
}