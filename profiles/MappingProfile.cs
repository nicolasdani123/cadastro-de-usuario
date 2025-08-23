using AutoMapper;
using WebApplication1.Models;
using WebApplication1.Dto;

namespace WebApplication1.Mapping
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
        }
    }
}
