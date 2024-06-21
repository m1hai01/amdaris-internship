using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.BlobStorage;

public interface IBlobFile
{
    [NotMapped]
    public Stream Content { get; set; }

    public string FileName { get; set; }
    public string ContentType { get; set; }
}