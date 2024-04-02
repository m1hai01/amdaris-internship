using BehavioralDesignPatterns.Subscribers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralDesignPatterns.Publisher
{
    public interface IOrderPublisher
    {
        void Attach(IOrderSubscriber subscriber);

        void Detach(IOrderSubscriber subscriber);

        void Notify();
    }
}