using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using YourLifeTasks.Domain.Entities;

namespace YourLifeTasks.Infrastructure.Db;

public class TasksDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<UserTask> UserTasks { get; set; }

    public DbSet<UserTasksGroup> UserTasksGroups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSnakeCaseNamingConvention();
    }
}