using BehavioralDesignPatterns.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralDesignPatterns.Subscribers
{
    public class EmailNotification : IOrderSubscriber
    {
        public void Update(Order order)
        {
            Console.WriteLine("EMail notification: Order status changed to  " + order.OrderStatus);
        }
    }
}