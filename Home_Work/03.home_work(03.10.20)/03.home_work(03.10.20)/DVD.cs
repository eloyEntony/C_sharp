using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.home_work_03._10._20_
{
    class DVD : Storage
    {
        double Speed_read { get; set; }
        double Speed_write { get; set; }
        //double Type { get; set; }
       

        public DVD (string name, string model, double read, double write, int type)
        {
            this.Name = name;
            this.Model = model;
            this.Speed_read = read;
            this.Speed_write = write;

            if(type == 1)
            {
                this.Memory = 4700; 
            }
            else if (type == 2)
            {
                this.Memory = 9000;
            }
        }

        public override void Show_info()
        {
            base.Show_info();
            Console.WriteLine($" Speed read  : {Speed_read}  Mb/s\n Speed write : {Speed_write}  Mb/s");
        }
    }
}
