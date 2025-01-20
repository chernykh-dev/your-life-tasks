namespace YourLifeTasks.Application.Requests.UserTasksGroups.GetAll;

public class GetAllUserTasksGroupsResponse(IEnumerable<SingleUserTasksGroup> userTasksGroups) : List<SingleUserTasksGroup>(userTasksGroups);