using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCode.Application.Validation;
using CleanCode.Domain.Models;
using CleanCode.Infrastructure;
using CleanCode.Infrastructure.Repository;
using CleanCode.Infrastructure.Validation;

namespace CleanCode
{
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
            //var repository = new Register(new SpeakerRepository());
            ISpeakerValidator validator = new SpeakerValidator();
            // Instantiate the repository
            var repository = new Register(new SpeakerRepository(), validator);

            // Register the speaker
            try
            {
                //validator.Validate(speaker);

                int? registrationResult = repository.RegisterSpeaker(speaker);
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