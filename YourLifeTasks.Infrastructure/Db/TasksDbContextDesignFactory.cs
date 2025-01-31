using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace YourLifeTasks.Infrastructure.Db;

public class TasksDbContextDesignFactory : IDesignTimeDbContextFactory<TasksDbContext>
{
    /// <summary>
    /// Создает экземпляр контекста
    /// </summary>
    /// <param name="args">Игнорируется</param>
    public TasksDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TasksDbContext>()
            .UseNpgsql("Host=127.0.0.1;Port=6432;Database=ExampleDb;Username=postgres;Password=postgres");

        return new TasksDbContext(optionsBuilder.Options);
    }

}