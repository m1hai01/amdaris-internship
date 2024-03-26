using System;
using System.Net;
using System.Net.Mail;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Email Notification Application!");
        Console.Write("Please enter your email address to subscribe to our newsletter: ");
        string emailAddress = Console.ReadLine();

        SendEmail(emailAddress);

        Console.WriteLine("Thank you for subscribing! An email has been sent to your address.");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    private static void SendEmail(string toEmailAddress)
    {
        // Sender's email credentials
        string fromEmailAddress = "mustucmihai78@gmail.com"; // Enter your email address
        string password = "*****"; // Enter your email password

        // Configure SMTP client
        using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
        {
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(fromEmailAddress, password);
            client.EnableSsl = true;

            // Create email message
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(fromEmailAddress);
                mailMessage.To.Add(toEmailAddress);
                mailMessage.Subject = "Thank You for Subscribing!";
                mailMessage.Body = "Dear Subscriber,\n\nThank you for subscribing to our newsletter!\n\nBest regards,\nYour Newsletter Team";

                // Send email
                client.Send(mailMessage);
            }
        }
    }
}

//This using statement ensures that the SmtpClient object is disposed of properly after its use.

//The Dispose method of SmtpClient is automatically called when the execution leaves the using block.

//Disposing of SmtpClient ensures that any network resources associated with the SMTP connection are released promptly after use, preventing memory leaks and maintaining efficient resource usage.