using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.home_work_03._05._20_
{
    class TeamLeader: IWorker
    {
        public void Build(House house)
        {
            if (house.Door != null)
            {
                Console.WriteLine("House is finished... THE END");
                house.Show_house();
                Console.WriteLine("               __   ______       ");
                Console.WriteLine("             /    \\        \\   ");
                Console.WriteLine("           /        \\        \\ ");
                Console.WriteLine("         /            \\      /| ");
                Console.WriteLine("       /                \\   / | ");
                Console.WriteLine("     /____________________\\/  | ");
                Console.WriteLine("     |   _           _    |   /  ");
                Console.WriteLine("     |  |_|   __    |_|   |  /   ");
                Console.WriteLine("     |       |  |         | /    ");
                Console.WriteLine("     |       |  |         |/     ");
                Console.WriteLine("     ======================      ");
            }
            else
            {
                Console.WriteLine("House is not finished...");
                house.Show_house();
                Console.WriteLine("==============================================");
            }
            
        }       
        
        public void Chack_work(House house)
        {            
            Build(house);
        }

    }
}
