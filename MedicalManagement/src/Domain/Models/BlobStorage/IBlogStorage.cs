namespace Domain.Models.BlobStorage;

public interface IBlobStorage<in T>
{
    /// <summary>
    /// This method uploads a file submitted with the request
    /// </summary>
    /// <param name="file">File for upload</param>
    /// <returns>Blob with status</returns>
    public Task<BlobResponse> UploadAsync(T file);

    /// <summary>
    /// This method deleted a file with the specified filename
    /// </summary>
    /// <param name="blobFilename">Filename</param>
    /// <returns>Blob with status</returns>
    public Task<BlobResponse> DeleteAsync(string fileName);

    /// <summary>
    /// This method returns a true if specified filename exist
    /// </summary>
    /// <returns>Boolean</returns>
    public Task<bool> CheckExist(string fileName);

    public Task ArchiveFile(string fileName);

    public Task<BlobResponse> UploadDataAsync(T file);
}