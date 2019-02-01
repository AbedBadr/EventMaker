using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.ViewModel;

namespace EventMaker.Handler
{
    class EventHandler
    {
        public EventViewModel EventViewModel { get; set; }

        public EventHandler()
        {
            EventViewModel = new EventViewModel();
        }

        public void CreateEvent()
    }
}
