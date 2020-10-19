using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NP_07_FTP
{
    class Program
    {
        static void Main(string[] args)
        {
            //ftp - file transfer protocol
            const string url = "ftp://92.52.138.128/";

            ////////////////////////////////

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string content = reader.ReadToEnd();
            Console.WriteLine(content);
            Console.WriteLine("Status " + response.StatusDescription);
            reader.Close();
            response.Close();

            ////////////////////////////////

            string folderName = "14.10.2020";
            request = (FtpWebRequest)WebRequest.Create(Path.Combine(url, folderName));
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.GetResponse();

            ////////////////////////////////

            string folderNam = "Roma";
            request = (FtpWebRequest)WebRequest.Create(Path.Combine(url, folderNam));
            request.Method = WebRequestMethods.Ftp.RemoveDirectory;
            request.GetResponse();

            ////////////////////////////////

            request = (FtpWebRequest)WebRequest.Create(Path.Combine(url, "index.html"));
            request.Method = WebRequestMethods.Ftp.UploadFile;

            using (WebClient client = new WebClient())
            {
                string text = client.DownloadString("https://google.com");
                //File.WriteAllText("index.html", text);
                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(text);
            }
            request.GetResponse();


            ////////////////////////////////


            request = (FtpWebRequest)WebRequest.Create(Path.Combine(url, "index.html"));
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            var tmp = request.GetResponse();

            Stream reader1 = response.GetResponseStream() ;

            byte[] buffer = new byte[1000];

            reader1.Read(buffer, 0, (int)reader1.Length);

            File.WriteAllBytes("index.html", buffer);

        }
    }
}
