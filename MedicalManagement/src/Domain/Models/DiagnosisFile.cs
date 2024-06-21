using Domain.Models.BlobStorage;
using Domain.Models.Diagnosis;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class DiagnosisFile : BaseEntity, IBlobFile
{
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public string FileUrl { get; set; }

    [NotMapped]
    public Stream Content { get; set; }

    public Guid DiagnoseId { get; set; }
    public Diagnose Diagnose { get; set; }
}