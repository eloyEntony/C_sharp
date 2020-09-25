using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace Text_Joiner
{

    public partial class MainWindow : Window
    {
        ObservableCollection<string> files = new ObservableCollection<string>();
        AutoResetEvent autoReset = new AutoResetEvent(false);
        FileInfo[] infos;
        Thread progressBar =null;
        Copy cw;
        Writer writer;
        int max;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = files;
            progressBar = new Thread(Progress);
            progressBar.IsBackground = true;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    lbPath.Content = dialog.SelectedPath;
                    DirectoryInfo d = new DirectoryInfo(dialog.SelectedPath);

                    //var extensions = new[] { "*.txt", "*.docx" };
                    //infos = extensions.SelectMany(ext => d.GetFiles(ext)).ToArray();

                    infos = d.GetFiles("*.txt");
                    foreach (var item in infos)                    
                        files.Add(item.FullName);
                    max = infos.Length;
                    pb.Maximum = max-1;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            cw = new Copy(autoReset, infos);
            autoReset.WaitOne();

            writer = new Writer(autoReset, cw);
            autoReset.WaitOne();
            
            progressBar.Start(max);
        }

        
        private void Progress(object max)
        {
            
            for (int i = 0; i < Convert.ToInt32(max); i++)
            {
                this.Dispatcher.Invoke(() => { pb.Value = i; });
                Thread.Sleep(10);
            }

            DialogResult result = (DialogResult)System.Windows.MessageBox.Show("Completed!");
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Dispatcher.Invoke(() => this.Close());
            }
        }
    }


    class Copy
    {
        Thread thread = null;
        AutoResetEvent resetEvent = new AutoResetEvent(false);
        static private string s;
        public string S { get => s; set => s = value; }
        public Copy(AutoResetEvent ev, FileInfo[] infos)
        {
            thread = new Thread(Read);
            resetEvent = ev;
            thread.Start(infos);
        }
        public void Read(object infos)
        {
            foreach (var item in (infos as FileInfo[]))
            {
                using (StreamReader sr = File.OpenText(item.FullName))                
                    s += sr.ReadLine() + "\n";                 
            }
            resetEvent.Set();
        }
    }

    class Writer
    {
        Thread thread = null;
        AutoResetEvent resetEvent = new AutoResetEvent(false);
        Copy cw;
        string path = Directory.GetCurrentDirectory() + "RES.txt";

        public Writer(AutoResetEvent ev, Copy copy)
        {
            thread = new Thread(Write);
            resetEvent = ev;
            cw = copy;
            thread.Start();
        }
        public void Write()
        {
            using (StreamWriter sw = File.CreateText(path))            
                sw.WriteLine(cw.S);
            
            resetEvent.Set();
        }

    }
}
