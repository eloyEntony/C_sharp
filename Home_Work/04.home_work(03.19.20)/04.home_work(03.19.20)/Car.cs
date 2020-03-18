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

        public virtual void Increase_speed() {
            this.Speed += 10;
        }

        public virtual void Decrease_speed() {
            this.Speed -= 10;
        }

        public virtual void Show_car() {
            Console.WriteLine($" Model : {Model}\n MAx speed : {Max_speed}\n Speed now : {Speed}");
        }

        public void Start()
        {
            Console.WriteLine(" >>> Start <<<");
        }
    }

}
