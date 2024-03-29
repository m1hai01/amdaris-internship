using CleanCode.Domain.Models;

namespace CleanCode.Application.Validation;

public interface ISpeakerValidator
{
    bool Validate(Speaker speaker);
}