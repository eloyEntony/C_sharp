using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.home_work_03._10._20_
{
    abstract class Storage
    {
        protected string Name { get; set; }
        protected string Model { get; set; }
        protected double Memory { get; set; }
        protected double Free_memory { get; set; }

        public double Get_Memory()
        {
            return this.Memory;
        }

        public void Copy_fails(int files_size)
        {
            this.Free_memory = this.Memory;

            if(this.Memory > files_size)
            {
                this.Free_memory -= files_size;
            }
            else
            {
                Console.WriteLine("add memory");
            }
            //Console.WriteLine("Free memory => {0}", this.Memory);
            Console.WriteLine("\n File is copy --- {0} Mb", files_size);
        }

        public double Get_info_free_memory()
        {
            return this.Free_memory;
        }

        public virtual void Show_info()
        {
            Console.WriteLine($" Name        : {this.Name}\n Model       : {this.Model}\n Memory size : {this.Memory} Mb");
        }

    }

}
