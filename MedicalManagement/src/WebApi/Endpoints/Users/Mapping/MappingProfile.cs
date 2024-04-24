using Application.Commands.User;
using AutoMapper;
using Domain.Models; // Assuming CreateUserCommand is in this namespace
using WebApi.Endpoints.Users.Create;

namespace WebApi.Endpoints.Users.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Request, CreateUserCommand>();
        }
    }
}