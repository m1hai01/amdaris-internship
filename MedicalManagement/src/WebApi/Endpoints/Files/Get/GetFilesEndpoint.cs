using Application.Abstractions;
using Carter;
using MedHub.Infrastructure.BlobStorage;

namespace WebApi.Endpoints.Files.Get
{
    public class GetFilesEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("upload", async (Guid diagnoseId, IUnitOfWork unitOfWork) =>
            {
                var filesList = await unitOfWork.DiagnosisFileRepository.GetAllByIdAsync(diagnoseId);
                return Results.Ok(filesList);
            });
        }
    }
}