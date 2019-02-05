using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
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
            EventVM.ECSingleton.Add(new Event(EventVM.Id, EventVM.Name, EventVM.Description, EventVM.Place, DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(EventVM.Date, EventVM.Time)));
        }

        public void DeleteEvent()
        {
            var messageDialog =
                new MessageDialog("Are you sure you want to delete the Event: " + EventViewModel.SelectedEvent.Name + "?");

            EventVM.ECSingleton.Remove(EventViewModel.SelectedEvent);
        }

        public void SetSelectedEvent(Event ev)
        {
            EventViewModel.SelectedEvent = ev;
        }
    }
}
