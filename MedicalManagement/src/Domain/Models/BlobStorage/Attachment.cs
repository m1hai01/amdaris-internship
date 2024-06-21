namespace Domain.Models.BlobStorage;

public class Attachment : IBlobFile
{
    public Stream Content { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
}