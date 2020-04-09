using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_03
{
    class Event
    {
        public string Title { get; set; }
        public string Event_place { get; set; }
        public DateTime Date { get; set; }
        public string Priority { get; set; }

        static public List<Event> eventList = new List<Event>();

        public Event(string title, string place, DateTime date, string priority )
        {
            this.Title = title;
            this.Date = date;
            this.Priority = priority;
            this.Event_place = place;
        }

        public static List<Event> GetEvent()
        {
            return eventList;
        }


    }
}
