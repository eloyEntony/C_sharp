using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.home_work_03._05._20_
{
    class Team
    {
        TeamLeader leader = new TeamLeader();
        //protected House house = new House();
        //Worker worker = new Worker();
        //bool exit = false;       

        public void Build_house(House house)
        {
           // worker.Build(house);
            //while (!exit)
            //{               

                if (house.Door != null)
                {
                    //exit = true;
                    Console.WriteLine("THE END");                
                }
                else
                {
                    Worker worker = new Worker();
                    worker.Build(house);
                    leader.Chack_work(house);
                }
            
            //}
        }
    }
}
