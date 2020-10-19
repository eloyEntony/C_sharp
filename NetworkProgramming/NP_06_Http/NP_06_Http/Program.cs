using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NP_06_Http
{
    class Program
    {
        

        static async Task Main(string[] args)
        {
            //await UsingWebAsync();
            //GetRequest();

            string url = "https://robohash.org/anton.png?set=set4";
            HttpClient client = new HttpClient();
            var res = await client.GetByteArrayAsync(url);
            File.WriteAllBytes("robot.png", res);


        }

        private static void GetRequest()
        {
            string url = "https://robohash.org/anton.png?set=set4";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse responce = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(responce.StatusCode);
            if (responce.StatusCode == HttpStatusCode.OK)
                Console.WriteLine("response OK");

            var stream = responce.GetResponseStream();
            var reader = new BinaryReader(stream);
            var res = reader.ReadBytes(1000);
            //byte[] buffer = new byte[];
            //stream.Read(buffer, 0, (int)responce.ContentLength);

            File.WriteAllBytes("res.png", res);
        }

        private static async Task UsingWebAsync()
        {
            using (WebClient client = new WebClient())
            {
                const string url = "https://mystat.itstep.org";
                await client.DownloadFileTaskAsync(url, "res.txt");
                //File.WriteAllText("index.html", res);

            }
        }
    }
}
