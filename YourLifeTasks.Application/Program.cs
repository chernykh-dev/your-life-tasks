using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using YourLifeTasks.Application.Configuration.AutoMapper;
using YourLifeTasks.Domain.Repositories;
using YourLifeTasks.Infrastructure.Db;
using YourLifeTasks.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DbSettings>(builder.Configuration.GetSection(nameof(DbSettings)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(x =>
{
    x.AddPolicy("all", y => y
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()
    );
});


builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddDbContext<TasksDbContext>(options =>
{
    var dbSettings = builder.Configuration.GetSection(nameof(DbSettings)).Get<DbSettings>();
    options.UseNpgsql(dbSettings!.ToConnectionString());
});
builder.Services.AddScoped<DbMediator>();

builder.Services.AddScoped<IUserTaskRepository, UserTaskRepository>();
builder.Services.AddScoped<IUserTasksGroupRepository, UserTaskGroupRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
await scope.ServiceProvider.GetRequiredService<TasksDbContext>().Database.MigrateAsync();

app.UseCors("all");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();