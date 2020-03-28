using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.File_stream
{
    class Work_with_files
    {
        string path { get; set; }
        string[] files;
        public Work_with_files(string path)
        {
            this.path = path;
            files = Directory.GetFiles(path, "*.html");
        }

        public void Show()
        {  
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"\n >>> [{i+1}].  {files[i]}");
            }
        }

        public void Delete_file()
        {
            Console.WriteLine("Enter # file to delete : ");
            int choise = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < files.Length; i++)
            {
                if (i == choise - 1)
                {
                    FileInfo file = new FileInfo(files[i]);
                    if (file.Exists)
                    {
                        file.Delete();
                        Console.WriteLine(" File Delete! ");
                    }

                }
            }
        }

        public void Rename()
        {
            Console.WriteLine("Enter # file to rename : ");
            int choise = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < files.Length; i++)
            {
                if (i == choise - 1)
                {
                    Console.WriteLine("Enter rename : ");
                    string name = Console.ReadLine();

                    FileInfo file = new FileInfo(files[i]);
                    if (file.Exists)
                    {
                        file.MoveTo(path + "\\" + name + ".html");
                        Console.WriteLine(" File Exists  and Rename! ");
                    }

                }
            }
        }

        public void Add_text_to_file()
        {

            Console.WriteLine("Enter # file to edit : ");
            int choise = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < files.Length; i++)
            {
                if (i == choise - 1)
                {
                    Console.WriteLine("Enter text to add : ");
                    string text = Console.ReadLine();

                    FileInfo file = new FileInfo(files[i]);
                    if (file.Exists)
                    {
                        using (StreamWriter sw = File.AppendText(files[i]))
                        {
                            sw.WriteLine(text);
                        }

                        Console.WriteLine(" File Edit! ");
                    }

                }
            }

        }

        public void Read_file()
        {
            Console.WriteLine("Enter # file to read : ");
            int choise = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < files.Length; i++)
            {
                if (i == choise - 1)
                {
                    FileInfo file = new FileInfo(files[i]);
                    if (file.Exists)
                    {
                        using (FileStream fs = File.OpenRead(files[i]))
                        {
                            byte[] b = new byte[1024];
                            UTF8Encoding temp = new UTF8Encoding(true);

                            while (fs.Read(b, 0, b.Length) > 0)
                            {
                                Console.WriteLine(temp.GetString(b));
                            }
                        }
                        Console.WriteLine(" File Read! ");
                    }

                }
            }
        }



    }
}
