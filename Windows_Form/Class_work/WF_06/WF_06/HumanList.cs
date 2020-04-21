using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_06
{
    [Serializable]
    public class HumanList
    {
        public List<Human> humanList { get; set; } = new List<Human>();

        public HumanList()
        {

        }

        public void Add(Human human)
        {
            humanList.Add(human);
        }
    }
}
