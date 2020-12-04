using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using DB_1;

namespace test
{
    public class Program
    {
        static List<AddressDTO> addresses;
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 2020);

            using (NetworkStream reader = client.GetStream())
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<AddressDTO>));
                addresses = (List<AddressDTO>)xml.Deserialize(reader);
            }

            foreach (var item in addresses)
            {
                Console.WriteLine(item);
            }
        }

        [Serializable]
        public class AddressDTO
        {           
            public string City { get; set; }
            public string Street { get; set; }
            public string House { get; set; }
            public int? Apartment { get; set; }
        }

        private void SerializeParams<T>(XDocument doc, List<T> paramList)
        {
            XmlSerializer serializer = new XmlSerializer(paramList.GetType());

            System.Xml.XmlWriter writer = doc.CreateWriter();

            serializer.Serialize(writer, paramList);

            writer.Close();
        }

        private List<T> DeserializeParams<T>(XDocument doc)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

            System.Xml.XmlReader reader = doc.CreateReader();

            List<T> result = (List<T>)serializer.Deserialize(reader);
            reader.Close();

            return result;
        }
    }
}
