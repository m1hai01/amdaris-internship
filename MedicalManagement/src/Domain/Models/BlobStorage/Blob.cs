namespace Domain.Models.BlobStorage;

public class Blob : IBlobFile
{
    public string? Uri { get; set; }
    public Stream Content { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
}