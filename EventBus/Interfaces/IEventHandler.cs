using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus0032.Interfaces
{
    public interface IEventHandler<TEvent> where TEvent : class
    {
        Task Handle(TEvent @event);
    }
}
