using YourLifeTasks.Domain.Entities;

namespace YourLifeTasks.Application.Requests.UserTasks;

public class UserTasksListResponse(IEnumerable<UserTask> userTasks) : List<UserTask>(userTasks);