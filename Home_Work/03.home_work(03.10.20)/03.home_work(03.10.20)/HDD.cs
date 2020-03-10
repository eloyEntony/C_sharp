using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.home_work_03._10._20_
{
    class HDD : Storage
    {
        double Speed { get; set; } = 2.0;
        int Number_of_sections { get; set; }
        int Volume_of_sections { get; set; }

        public HDD(string name, string model, int num_sec, int volum_sec)
        {
            this.Name = name;
            this.Model = model;
            this.Number_of_sections = num_sec;
            this.Volume_of_sections = volum_sec;
            this.Memory = this.Volume_of_sections * this.Number_of_sections;
        }

        public override void Show_info()
        {
            base.Show_info();
            Console.WriteLine($" Speed       : 2.0\n Number of sections : {Number_of_sections}\n Volume of sections : {Volume_of_sections} Mb");
        }
    }
}
