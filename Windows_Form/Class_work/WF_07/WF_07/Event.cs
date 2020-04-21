using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_07
{
    [Serializable]
    public class Event
    {
        public string Name { get; set;}
        public DateTime Date { get; set; }
        public string Priority { get; set; }

        public Event()
        {

        }

        public override string ToString()
        { 
            return $"{Date.ToShortDateString()} ~~~ {Name} ~~~ {Priority}";
        }
    }
}
