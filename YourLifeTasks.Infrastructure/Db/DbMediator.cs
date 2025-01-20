namespace YourLifeTasks.Infrastructure.Db;

public class DbMediator(TasksDbContext dbContext)
{
    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}