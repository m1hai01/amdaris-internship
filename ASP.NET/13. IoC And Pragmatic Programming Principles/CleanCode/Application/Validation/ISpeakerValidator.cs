using CleanCode.Domain;

namespace CleanCode.Application.Validation;

public interface ISpeakerValidator
{
    bool Validate(Speaker speaker);
}