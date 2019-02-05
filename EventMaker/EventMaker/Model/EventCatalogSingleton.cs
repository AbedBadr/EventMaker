using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Persistency;

namespace EventMaker.Model
{
    class EventCatalogSingleton
    {
        private static EventCatalogSingleton _instance/*= new EventCatalogSingleton()*/;

        public static EventCatalogSingleton Instance
        {
            get { return _instance ?? (_instance = new EventCatalogSingleton()); }
        }

        public ObservableCollection<Event> Events { get; set; }

        private EventCatalogSingleton()
        {
            Events = new ObservableCollection<Event>();
            //LoadTestEvents();
            LoadFraFil();
        }

        public async void LoadEventsAsync()
        {
            var events = await PersistencyService.LoadEventsFromJsonAsync();
            if (events != null)
            {
                foreach (var ev in events)
                {
                    Events.Add(ev);
                }
            }
        }

        public async void LoadFraFil()
        {
            List<Event> myEvents = new List<Event>();
            myEvents = await PersistencyService.LoadEventsFromJsonAsync();

            foreach (Event ev in myEvents)
            {
                Events.Add(ev);
            }
        }

        public void LoadTestEvents()
        {
            Events.Add(new Event(1, "Fødselsdag", "Maher's fødselsdag", "Vapnagård 11", new DateTime(2019, 3, 10, 9, 45, 00)));
            Events.Add(new Event(2, "Eksamen", "SWC eksamen", "Maglegårdsvej 2", new DateTime(2019, 7, 16, 8, 30, 00)));
            Events.Add(new Event(3, "Bryllup", "Maher's bryllup", "Vapnagård 20", new DateTime(2019, 10, 20, 14, 00, 00)));
        }

        public void Add(int id, string name, string description, string place, DateTime dateTime)
        {
            Events.Add(new Event(id, name, description, place, dateTime));
            PersistencyService.SaveEventsAsJsonAsync(Events);
        }

        public void Add(Event ev)
        {
            Events.Add(ev);
            PersistencyService.SaveEventsAsJsonAsync(Events);
        }

        public void Remove(Event ev)
        {
            Events.Remove(ev);
            PersistencyService.SaveEventsAsJsonAsync(Events);
        }
    }
}
