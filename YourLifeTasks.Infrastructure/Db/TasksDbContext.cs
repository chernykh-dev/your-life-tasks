using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YourLifeTasks.Domain.Entities;

namespace YourLifeTasks.Infrastructure.Db;

public class TasksDbContext : DbContext
{
    public DbSet<UserTask> UserTasks { get; set; }

    public TasksDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql("Server=localhost;Database=your-life-tasks-db;Username=chernykhav;Password=chernykhav")
            .UseSnakeCaseNamingConvention();
    }
}