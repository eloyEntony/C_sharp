using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_07
{
    [Serializable]
    public class Event_List
    {
        public List<Event> Events = new List<Event>();

        public Event_List()
        {

        }

        public void AddEvent(Event e)
        {
            Events.Add(e);
        }

        public void Clear()
        {
            Events.Clear();
        }
    }
}
