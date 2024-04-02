using BehavioralDesignPatterns.Publisher;
using BehavioralDesignPatterns.Subscribers;

internal class Program
{
    private static void Main(string[] args)
    {
        // Create Order
        Order order = new Order();

        // Attach observers
        EmailNotification emailNotification = new EmailNotification();
        SMSNotification smsNotification = new SMSNotification();
        order.Attach(emailNotification);
        order.Attach(smsNotification);

        // Customer places order
        order.OrderStatus = "Processing";

        // Staff member fulfills order
        order.OrderStatus = "Ready for shipping";

        // Detach an observer (unsubscribe)
        order.Detach(emailNotification);

        // Customer updates order
        order.OrderStatus = "Shipped";
    }
}