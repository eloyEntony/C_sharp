using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_01_Dynamic_var
{
    class DenamicTest
    {
        public int MyProperty { get; set; }
        public dynamic Test { get; set; }

        public void SetValue(dynamic value)
        {
            int i = 150689;
            if (value is int)
                Test = i;
            else
                Test = value;
        }
        public DenamicTest()
        {

        }
        public override string ToString()
        {
            return $"{MyProperty} =>> Test {Test} {Test.GetType().Name}";
        }
    }
}
