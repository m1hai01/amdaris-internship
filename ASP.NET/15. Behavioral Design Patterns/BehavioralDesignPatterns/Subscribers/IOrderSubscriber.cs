using BehavioralDesignPatterns.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralDesignPatterns.Subscribers
{
    public interface IOrderSubscriber
    {
        void Update(Order order);
    }
}