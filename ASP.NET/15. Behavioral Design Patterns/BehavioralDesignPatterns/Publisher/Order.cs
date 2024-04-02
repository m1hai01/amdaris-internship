using BehavioralDesignPatterns.Subscribers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralDesignPatterns.Publisher
{
    public class Order : IOrderPublisher
    {
        private List<IOrderSubscriber> _subscribers = new List<IOrderSubscriber>();
        private string _orderStatus;

        public string OrderStatus
        {
            get { return _orderStatus; }
            set
            {
                _orderStatus = value;
                Notify();
            }
        }

        public void Attach(IOrderSubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void Detach(IOrderSubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void Notify()
        {
            foreach (var subscriber in _subscribers)
            {
                // Update all observers about the change in order status
                subscriber.Update(this);
            }
        }
    }
}