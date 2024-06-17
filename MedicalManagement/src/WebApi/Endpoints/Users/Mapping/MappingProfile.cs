using Application.Commands.Users;
using AutoMapper;
using Domain.Models; // Assuming CreateUserCommand is in this namespace
using WebApi.Endpoints.Users.Create;
using WebApi.Endpoints.Users.Get;

namespace WebApi.Endpoints.Users.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Request, CreateUserCommand>();
            CreateMap<User, UserResponse>().ReverseMap();
        }
    }
}