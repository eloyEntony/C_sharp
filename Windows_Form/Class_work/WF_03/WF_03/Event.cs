using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_03
{
    [Serializable]
    public class Event
    {
        public string Title { get; set; }
        public string Event_place { get; set; }
        public DateTime Date { get; set; }
        public string Priority { get; set; }      

        public Event() { }
        public override string ToString()
        {
            return $"{Date}  {Priority} {Title} {Event_place}";
        }


    }
}
