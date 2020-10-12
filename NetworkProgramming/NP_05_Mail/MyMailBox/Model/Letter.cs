using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMailBox.Model
{
    public class Letter
    {
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Date { get; set; }
    }
}
