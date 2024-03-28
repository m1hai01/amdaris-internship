using System;
using System.Collections.Generic;

public class Notification
{
    public string Message { get; set; }
    public string Receiver { get; set; }
}

public class File
{
    public string FileName { get; set; }
    public string FileType { get; set; }
}

//ISP
public interface IFileNotification
{
    void AttachFile(File file);
}

//LSP
//allowing derived notification sender classes to be substitutable for their base interface (INotificationSender) without altering the behavior expected by the NotificationService.
public interface INotificationSender
{
    void SendNotification(Notification notification);
}

public class EmailNotificationSender : INotificationSender, IFileNotification
{
    public void SendNotification(Notification notification)
    {
        Console.WriteLine($"Send email to {notification.Receiver} ");
        Console.WriteLine($"Email: {notification.Message} ");
    }

    public void AttachFile(File file)
    {
        Console.WriteLine($" File name is {file.FileName}");
        Console.WriteLine($" File type is {file.FileType}");
    }
}

public class SMSNotificationSender : INotificationSender
{
    public void SendNotification(Notification notification)
    {
        Console.WriteLine($"Send sms to {notification.Receiver} ");
        Console.WriteLine($"Sms: {notification.Message} ");
    }
}

public class PushNotificationSender : INotificationSender
{
    public void SendNotification(Notification notification)
    {
        Console.WriteLine($"Send push notification to {notification.Receiver} ");
        Console.WriteLine($"Notification: {notification.Message} ");
    }
}

//coordinating the sending of notifications via different channels.
//Open/Closed Principle (OCP): The NotificationService is open for extension but closed for modification.
//DIP High-level modules (like NotificationService) depend on abstractions (INotificationSender), not concrete implementations.
public class NotificationService
{
    private readonly List<INotificationSender> _senders;

    public NotificationService(List<INotificationSender> senders)
    {
        _senders = senders;
    }

    public void SendNotification(Notification notification, File file = null)
    {
        foreach (var sender in _senders)
        {
            sender.SendNotification(notification);

            if (sender is IFileNotification && file != null)
            {
                IFileNotification fileSender = (IFileNotification)sender;
                fileSender.AttachFile(file);
            }
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        // Create instances of notification senders
        var emailSender = new EmailNotificationSender();
        var smsSender = new SMSNotificationSender();
        var pushSender = new PushNotificationSender();

        // Create a list of notification senders
        var senders = new List<INotificationSender> { emailSender, smsSender, pushSender };

        // Initialize notification service with the list of senders
        var notificationService = new NotificationService(senders);

        // Example usage
        var notification = new Notification
        {
            Receiver = "Mihai",
            Message = "This is a test notification."
        };

        var file = new File
        {
            FileName = "document",
            FileType = "pdf"
        };

        notificationService.SendNotification(notification, file);
    }
}