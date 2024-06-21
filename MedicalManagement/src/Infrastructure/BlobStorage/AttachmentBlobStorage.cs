using Domain.Models.BlobStorage;
using Domain.Shared;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MedHub.Infrastructure.BlobStorage;

public interface IAttachmentBlobStorage : IBlobStorage<Attachment>;

public class AttachmentBlobStorage(IOptions<AzureStorageSettings> azureStorageSettings, ILogger<AttachmentBlobStorage> logger)
    : BlobStorage<AttachmentBlobStorage, Attachment>(azureStorageSettings.Value.ConnectionString,
        azureStorageSettings.Value.Attachments, logger), IAttachmentBlobStorage;