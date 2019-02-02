using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Converter;
using EventMaker.Model;
using EventMaker.ViewModel;

namespace EventMaker.Handler
{
    class EventHandler
    {
        public EventViewModel EventVM { get; set; }

        public EventHandler(EventViewModel evm)
        {
            EventVM = evm;
        }

        public void CreateEvent()
        {
            EventVM.ECSingleton.Events.Add(new Event(EventVM.Id, EventVM.Name, EventVM.Description, EventVM.Place, DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(EventVM.Date, EventVM.Time)));
        }
    }
}
