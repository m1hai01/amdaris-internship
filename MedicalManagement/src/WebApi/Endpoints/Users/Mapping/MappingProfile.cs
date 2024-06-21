using Application.Commands.Doctor;
using Application.Commands.Patient;
using Application.Commands.Treatment;
using Application.Commands.Users;
using AutoMapper;
using Domain.Models; // Assuming CreateUserCommand is in this namespace
using Domain.Models.Diagnosis;
using WebApi.Endpoints.Doctor;
using WebApi.Endpoints.Patient;
using WebApi.Endpoints.Treatments.Create;
using WebApi.Endpoints.Treatments.GetAll;
using WebApi.Endpoints.Treatments.Update;
using WebApi.Endpoints.Users.Create;
using WebApi.Endpoints.Users.Get;

namespace WebApi.Endpoints.Users.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User mappings
            CreateMap<Request, CreateUserCommand>();
            CreateMap<User, UserResponse>().ReverseMap();

            // Treatment mappings
            CreateMap<TreatmentCreateRequest, CreateTreatmentCommand>();
            CreateMap<TreatmentUpdateRequest, UpdateTreatmentCommand>();
            CreateMap<Treatment, TreatmentGetAllResponse>().ReverseMap();

            CreateMap<CreateDoctorRequest, CreateDoctorCommand>();
            CreateMap<CreatePatientRequest, CreatePatientCommand>();
        }
    }
}