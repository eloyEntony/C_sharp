using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.home_work_03._19._20_
{
    class Game
    {
        Car sport;
        Car passenger;
        Car truck;
        Car bus;

        List<Car> ts = new List<Car>();

        public Game()
        {
            var rand = new Random();
            int speed = 0;

            ts.Add(sport = new Sport_Car(speed = rand.Next(90, 200)));           
            ts.Add(passenger = new Passenger(speed = rand.Next(90, 200)));
            ts.Add(truck = new Truck(speed = rand.Next(90, 200)));
            ts.Add(bus = new Bus(speed = rand.Next(90, 200)));
        }

        public event Action Finish_event;

        public void Start_game()
        {
            foreach (Car item in ts)
            {
                item.Start();
            }
        }

        public void Go()
        {
            int counter_winner = 0;
            int km = 0;
            var rand = new Random();
            bool exit = false;

            while (!exit)
            {
                for (int i = 0; i < 4; i++)
                {
                    ts[i].Accelerate(km = rand.Next(0, 10));  // генерує скільки кілометрів проїде машина
                }
                Console.WriteLine("----------------------------------");
                for (int i = 0; i < 4; i++)
                {
                    if (ts[i].Distance >= 100 && counter_winner == 0)
                    {
                        //Console.WriteLine("<<<<<<<----->>>>>>>");
                        //ts[i].Show_car();
                        ts[i].Winner = true;
                        counter_winner++;
                        Finish_event();
                        exit = true;
                    }
                }
            }
        }

        public void End()
        {
            Console.WriteLine("==== FINISH ====");
            foreach (Car item in ts)
            {
                if (item.Winner == true)
                {
                    item.Show_car();
                    break;
                }
                
            }
            Console.WriteLine("----------------------------------");
        }

        public void Show_all_car()
        {
            foreach (Car item in ts)
            {
                item.Show_car();
                Console.WriteLine("----------------------------------");
            }            
        }
    }
}
