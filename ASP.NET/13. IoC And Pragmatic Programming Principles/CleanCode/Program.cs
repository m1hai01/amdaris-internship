using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCode.Application.Validation;
using CleanCode.Domain;
using CleanCode.Infrastructure;

namespace CleanCode
{
    // Define IRepository interface
    public interface IRepository
    {
        int? SaveSpeaker(Speaker speaker);
    }

    // Define Session class
    public class Session
    {
        public string Title { get; set; }
        public string Description { get; set; }
        // You can add more properties as needed
    }

    // Define WebBrowser class
    public class WebBrowser
    {
        public string Name { get; set; }
        public int MajorVersion { get; set; }

        // You can add more properties as needed
        public enum BrowserName
        {
            InternetExplorer,
            Chrome,
            Firefox,
            Safari,
            Edge
            // Add more browsers as needed
        }
    }

    // Implement the IRepository interface
    public class SpeakerRepository : IRepository
    {
        public int? SaveSpeaker(Speaker speaker)
        {
            // Implement saving logic here
            Console.WriteLine("Speaker saved successfully.");
            return 1; // For demonstration
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            // Instantiate the Speaker object
            Speaker speaker = new Speaker
            {
                FirstName = "Mihai",
                LastName = "Biden",
                Email = "mihai.biden@example.com",
                Exp = 5,
                HasBlog = true,
                BlogURL = "https://example.com",
                Browser = new WebBrowser { Name = WebBrowser.BrowserName.Chrome.ToString(), MajorVersion = 90 },
                Certifications = new List<string> { "Certification1", "Certification2", "Certification3" },
                Employer = "Microsoft",
                RegistrationFee = 0, // Will be calculated
                Sessions = new List<Session> { new Session { Title = "Session Title", Description = "Session Description" } }
            };

            // Instantiate the repository
            IRepository repository = new SpeakerRepository();
            ISpeakerValidator validator = new SpeakerValidator();

            // Register the speaker
            try
            {
                validator.Validate(speaker);

                repository.RegisterSpeaker(speaker);
                int? registrationResult = speaker.Register(repository);
                Console.WriteLine("Registration fee: $" + speaker.RegistrationFee);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Registration failed: " + ex.Message);
            }

            Console.ReadLine(); // Keep console window open
        }
    }
}