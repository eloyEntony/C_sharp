using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.home_work_03._19._20_
{
    class Car
    {
        public int Speed { get; set; }
        public int Max_speed { get; set; }
        public string Model { get; set; }
        public int Distance { get; set; }
        public bool Winner { get; set; } = false;
        //public event Action<int> Go;

        public virtual void Increase_speed() {
            this.Speed += 10;
        }

        public virtual void Decrease_speed() {
            this.Speed -= 10;
        }

        public virtual void Show_car() {
            Console.WriteLine($" Model     : {Model}\n MAx speed : {Max_speed} km/h\n Speed now : {Speed} km/h \n Distans   : {Distance} km");
        }

        public void Start()
        {
            Console.WriteLine(" >>> Start <<<");
        }

        public virtual void Accelerate( int km )
        {
            this.Speed += 10;
            this.Distance += km;

            if (this.Speed > this.Max_speed)
            {
                Console.WriteLine(" Too fast... ");
                this.Speed = this.Max_speed;
                //Go(Speed);
            }
            Console.WriteLine($" >>> Speed   = {this.Speed} km/h");
            Console.WriteLine($" >>> Distans = {this.Distance} km");
        }

        public void Break(int speed)
        {
            this.Speed -= speed;
            Console.WriteLine($"After break stop {this.Speed}");
        }

        public void Stop(int speed)
        {
            this.Speed = speed;
            Console.WriteLine($"After full stop {this.Speed}");
        }


    }

}
