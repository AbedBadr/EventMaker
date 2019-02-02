using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EventMaker.Common;
using EventMaker.Handler;
using EventMaker.Model;

namespace EventMaker.ViewModel
{
    class EventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTimeOffset Date { get; set; }
        public TimeSpan Time { get; set; }

        public EventCatalogSingleton ECSingleton { get; set; }

        public Handler.EventHandler EventHandler { get; set; }

        public ICommand CreateEventCommand { get; set; }

        public EventViewModel()
        {
            ECSingleton = EventCatalogSingleton.Instance;
            DateTime dt = System.DateTime.Now;

            Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, 0, new TimeSpan());
            Time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            EventHandler = new Handler.EventHandler(this);
            CreateEventCommand = new RelayCommand(EventHandler.CreateEvent);
        }
    }
}
