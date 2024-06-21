using System.Reflection.Metadata;

namespace Domain.Models.BlobStorage;

public class BlobResponse
{
    public string? Status { get; set; }
    public bool Error { get; set; }
    public Blob Blob { get; set; } = new();
}