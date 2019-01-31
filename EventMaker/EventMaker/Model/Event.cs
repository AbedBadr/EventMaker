using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMaker.Model
{
    class Event
    {
        private int _id;
        private string _name;
        private string _description;
        private string _place;
        private DateTime _dateTime;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTime DateTime { get; set; }

        public Event(int id, string name, string description, string place, DateTime dateTime)
        {
            _id = id;
            _name = name;
            _description = description;
            _place = place;
            _dateTime = dateTime;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {_id}, {nameof(Name)}: {_name}, {nameof(Description)}: {_description}, {nameof(Place)}: {_place}, {nameof(DateTime)}: {_dateTime}";
        }
    }
}
