using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Serializable]
    public class AddressDTO
    {
        public int ID { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public int? Apartment { get; set; }

        public override string ToString()
        {
            return $"{City} {Street} {House} / {Apartment}";
        }
    }
}
