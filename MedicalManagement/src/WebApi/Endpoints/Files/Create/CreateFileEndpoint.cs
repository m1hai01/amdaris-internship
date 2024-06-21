using Application.Abstractions;
using Carter;
using Domain.Models;
using Domain.Models.BlobStorage;
using MedHub.Infrastructure.BlobStorage;
using MediatR;

namespace WebApi.Endpoints.Files.Create
{
    public class CreateFileEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("upload/{diagnoseId:guid}", async (IFormFile file,
                Guid diagnoseId,
                IAttachmentBlobStorage storage,
                IUnitOfWork unitOfWork) =>
            {
                var attachment = new Attachment
                {
                    Content = file.OpenReadStream(),
                    FileName = file.FileName,
                    ContentType = file.ContentType
                };

                if (await storage.CheckExist(attachment.FileName))
                    await storage.DeleteAsync(attachment.FileName);

                var response = await storage.UploadAsync(attachment);

                if (response.Error)
                    throw new Exception($"Can not upload image, status: {response.Status}");

                var diagnosisFile = new DiagnosisFile()
                {
                    FileName = file.FileName,
                    Content = response.Blob.Content,
                    ContentType = file.ContentType,
                    FileUrl = response.Blob.Uri,
                    Id = Guid.NewGuid()
                };

                var diagnosis = await unitOfWork.DiagnosisRepository.GetByIdAsync(diagnoseId);
                diagnosis.DiagnoseFiles.Add(diagnosisFile);

                await unitOfWork.DiagnosisFileRepository.AddAsync(diagnosisFile);

                await unitOfWork.CommitAsync();

                return response.Error
                    ? Results.BadRequest(new List<string> { $"Can not upload image, status: {response.Status}" })
                    : Results.Ok(response.Blob);
            })
            .DisableAntiforgery();
        }
    }
}