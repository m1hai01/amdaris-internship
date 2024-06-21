using Application.Abstractions;
using Domain.Models.BlobStorage;
using Infrastructure.Repository;
using MedHub.Infrastructure.BlobStorage;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration;

internal static class ConfigureRepositories
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IDiagnosisRepository, DiagnosisRepository>();
        services.AddScoped<ITreatmentRepository, TreatmentRepository>();
        services.AddScoped<IMedicalCardRepository, MedicalCardRepository>();
        services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IAttachmentBlobStorage, AttachmentBlobStorage>();
        services.AddScoped<IDiagnosisFileRepository, DiagnosisFileRepository>();

        return services;
    }
}