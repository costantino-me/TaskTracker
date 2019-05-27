using System.Linq;
using AutoMapper;
using TaskTracker.API.Dtos;
using TaskTracker.API.Models;

namespace TaskTracker.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForDetailedDto>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<ClientTaskForAddDto, ClientTask>();
            CreateMap<ClientTask, ClientTaskForDetailedDto>();
        }
    }
}