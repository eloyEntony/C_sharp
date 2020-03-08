using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.home_work_03._05._20_
{
    class Worker: IWorker
    {
        //House house = new House();
       //bool exit = false;

       public void Build(House house)
       {
            //while (!exit)
            //{
                if(house.Basement == null)
                {
                    house.Basement = "======================";
                }
                else if(house.Walls == null)
                {
                    house.Walls = "|\t |\t \n\t  |\t |\t \n\t  |\t |\t \n\t  |\t |\t";
                }
                else if (house.Roof == null)
                {
                    house.Roof = "   __\n\t   /  \\\n\t  /    \\\n\t /______\\";
                }
                else if (house.Window == null)
                {
                    house.Window = "_\n\t  |_|";
                }
                else if (house.Door == null)
                {
                    house.Door = "__\n\t|  |\n\t|__|";
                }
                
                //else 
                //{
                //    house.Show_house();
                //    exit = true;
                //}
            //}
       }
    }
}
