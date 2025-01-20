using AutoMapper;
using YourLifeTasks.Application.Requests.UserTasks.Get;
using YourLifeTasks.Application.Requests.UserTasksGroups.Get;
using YourLifeTasks.Domain.Entities;

namespace YourLifeTasks.Application.Configuration.AutoMapper;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<UserTask, GetUserTaskResponse>()
            .ForMember(x => x.UserTasksGroupId,
                x => x.MapFrom(y => y.UserTasksGroup.Id));
    }
}