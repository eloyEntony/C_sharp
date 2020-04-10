using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_03
{
    [Serializable]
    public class EventList
    {
        public List<Event> Events { get; set; } = new List<Event>();
        public EventList()
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
        public void SaveToJson()
        {
            string json = JsonConvert.SerializeObject(Events);
            File.WriteAllText("1.json", json);
        }
    }
}
