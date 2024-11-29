namespace YourLifeTasks.Infrastructure.Db;

public class DbMedator(TasksDbContext dbContext)
{
    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}