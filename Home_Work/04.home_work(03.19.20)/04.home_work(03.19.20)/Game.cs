using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.home_work_03._19._20_
{
    class Game
    {
        Sport_Car sport = new Sport_Car();
        Passenger passenger = new Passenger();
        Truck truck = new Truck();
        Bus bus = new Bus();

        public void Start_game()
        {
            sport.Start();
            passenger.Start();
            truck.Start();
            bus.Start();

        }
    }
}
