using CleanCode.Application.Constants;
using CleanCode.Application.Validation;
using CleanCode.Domain.Models;

namespace CleanCode.Infrastructure.Validation;

public class SpeakerValidator : ISpeakerValidator
{
    public bool Validate(Speaker speaker)
    {
        if (string.IsNullOrWhiteSpace(speaker.FirstName))
            throw new ArgumentNullException(nameof(speaker.FirstName), "First Name is required.");
        if (string.IsNullOrWhiteSpace(speaker.LastName))
            throw new ArgumentNullException(nameof(speaker.LastName), "Last Name is required.");
        if (string.IsNullOrWhiteSpace(speaker.Email))
            throw new ArgumentNullException(nameof(speaker.Email), "Email is required.");

        if (!IsQualifiedSpeaker(speaker))
            throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet our arbitrary and capricious standards.");

        if (!speaker.Sessions.Any())
            throw new NoSessionsApprovedException("No sessions approved.");

        return true;
    }

    private bool IsQualifiedSpeaker(Speaker speaker)
    {
        var prohibitedDomains = new List<string> { "aol.com", "hotmail.com", "prodigy.com", "CompuServe.com" };

        var isQualified = speaker.Exp > 10 || speaker.HasBlog || speaker.Certifications?.Count > 3 || GoodEmployers.List.Contains(speaker.Employer);

        if (!isQualified)
        {
            string emailDomain = speaker.Email.Split('@').Last();
            isQualified = !prohibitedDomains.Contains(emailDomain) &&
                          !(speaker.Browser.Name == WebBrowser.BrowserName.InternetExplorer.ToString() && speaker.Browser.MajorVersion < 9);
        }

        return isQualified;
    }
}