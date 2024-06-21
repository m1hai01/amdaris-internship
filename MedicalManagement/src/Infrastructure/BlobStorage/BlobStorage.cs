using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Domain.Models.BlobStorage;
using Microsoft.Extensions.Logging;

namespace MedHub.Infrastructure.BlobStorage;

public abstract class BlobStorage<T, TFile>(string storageConnectionString, string storageContainerName, ILogger<T> logger)
    : IBlobStorage<TFile>
    where TFile : IBlobFile
{
    protected readonly BlobContainerClient BlobServiceClient = new(storageConnectionString, storageContainerName);
    protected readonly ILogger<T> Logger = logger;

    public async Task<BlobResponse> DeleteAsync(string fileName)
    {
        var file = BlobServiceClient.GetBlobClient(fileName);

        try
        {
            // Delete the file
            await file.DeleteAsync();
        }
        catch (RequestFailedException ex)
            when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
        {
            // File did not exist, log to console and return new response to requesting method
            Logger.LogError($"File {fileName} was not found.");
            return new BlobResponse { Error = true, Status = $"File with name {fileName} not found." };
        }

        // Return a new BlobResponseDto to the requesting method
        return new BlobResponse { Error = false, Status = $"File: {fileName} has been successfully deleted." };
    }

    public async Task<BlobResponse> UploadAsync(TFile file)
    {
        // Create new upload response object that we can return to the requesting method
        var response = new BlobResponse();

        try
        {
            // Get a reference to the blob just uploaded from the API in a container from configuration settings
            var client = BlobServiceClient.GetBlobClient(file.FileName);

            // Upload the file async
            await client.UploadAsync(file.Content);

            // Everything is OK and file got uploaded
            response.Status = $"File {file.FileName} Uploaded Successfully";
            response.Error = false;
            response.Blob.Uri = client.Uri.AbsoluteUri;
            response.Blob.FileName = client.Name;
        }
        // If the file already exists, we catch the exception and do not upload it
        catch (RequestFailedException ex)
            when (ex.ErrorCode == BlobErrorCode.BlobAlreadyExists)
        {
            Logger.LogError($"File with name {file.FileName} already exists in container. Set another name to store the file in the container: '{BlobServiceClient.Name}.'");
            response.Status = $"File with name {file.FileName} already exists. Please use another name to store your file.";
            response.Error = true;
            return response;
        }
        // If we get an unexpected error, we catch it here and return the error message
        catch (RequestFailedException ex)
        {
            Logger.LogError(ex.ToString());
            response.Status = $"Unexpected error: {ex.StackTrace}. Check log with StackTrace ID.";
            response.Error = true;
            return response;
        }

        // Return the BlobUploadResponse object
        return response;
    }

    public async Task<bool> CheckExist(string fileName)
    {
        var file = BlobServiceClient.GetBlobClient(fileName);

        return await file.ExistsAsync();
    }

    public async Task ArchiveFile(string fileName)
    {
        var blobClient = BlobServiceClient.GetBlobClient(fileName);

        var properties = await blobClient.GetPropertiesAsync();

        if (properties.Value.AccessTier != AccessTier.Archive)
            await blobClient.SetAccessTierAsync(AccessTier.Archive);
    }

    public async Task<BlobResponse> UploadDataAsync(TFile file)
    {
        if (await CheckExist(file.FileName))
        {
            await DeleteAsync(file.FileName);
        }

        var response = await UploadAsync(file);

        if (response.Error)
        {
            throw new Exception($"Can not upload image, status: {response.Status}");
        }

        return response;
    }
}