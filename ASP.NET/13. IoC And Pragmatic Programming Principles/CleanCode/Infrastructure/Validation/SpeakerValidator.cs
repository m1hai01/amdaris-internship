using CleanCode.Application.Constants;
using CleanCode.Application.Validation;
using CleanCode.Domain;

namespace CleanCode.Infrastructure.Validation;

public class SpeakerValidator : ISpeakerValidator
{
    public bool Validate(Speaker speaker)
    {
        if (string.IsNullOrWhiteSpace(FirstName))
            throw new ArgumentNullException(nameof(FirstName), "First Name is required.");
        if (string.IsNullOrWhiteSpace(LastName))
            throw new ArgumentNullException(nameof(LastName), "Last Name is required.");
        if (string.IsNullOrWhiteSpace(Email))
            throw new ArgumentNullException(nameof(Email), "Email is required.");

        if (!IsQualifiedSpeaker())
            throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet our arbitrary and capricious standards.");

        if (!Sessions.Any())
            throw new NoSessionsApprovedException("No sessions approved.");
    }

    private bool IsQualifiedSpeaker()
    {
        var prohibitedDomains = new List<string> { "aol.com", "hotmail.com", "prodigy.com", "CompuServe.com" };

        var isQualified = Exp > 10 || HasBlog || Certifications?.Count > 3 || GoodEmployers.List.Contains(Employer);

        if (!isQualified)
        {
            string emailDomain = Email.Split('@').Last();
            isQualified = !prohibitedDomains.Contains(emailDomain) &&
                          !(Browser.Name == WebBrowser.BrowserName.InternetExplorer.ToString() && Browser.MajorVersion < 9);
        }

        return isQualified;
    }
}