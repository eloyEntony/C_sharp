using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CopyProgram
{
    public partial class MainWindow : Window
    {        
        string[] files;
        Thread t1;
        Thread t2;
        long filesize;
        public MainWindow()
        {
            InitializeComponent();
            t1 = new Thread(Progress);
            t2 = new Thread(new ThreadStart(StartCopy));
            t1.IsBackground = true;
            t2.IsBackground = true;
        }
        int max;
        private void Progress(object max)
        {            
            for (int i = 0; i < Convert.ToInt32(max); i++)
            {
                this.Dispatcher.Invoke(() => { progressBar.Value = i;});
                Thread.Sleep(10);
            }
           
            DialogResult result = (DialogResult)System.Windows.MessageBox.Show("Completed!");
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                Dispatcher.Invoke(() => this.Close()) ;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if(result == System.Windows.Forms.DialogResult.OK)
                {
                    DirectoryInfo d = new DirectoryInfo(dialog.SelectedPath);
                    tbSource.Text = d.FullName;
                }                              
            }
        }
        
        private void LoadFiles(string targetDirectory)
        {
            files = Directory.GetFiles(targetDirectory);

            DirectoryInfo directoryInfo = new DirectoryInfo(targetDirectory);
            FileInfo[] fileInfos = directoryInfo.GetFiles();
            foreach (var item in fileInfos)
            {
                filesize += item.Length;
            }
            max = Convert.ToInt32(filesize/10000);
            progressBar.Maximum = max-1;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    DirectoryInfo d = new DirectoryInfo(dialog.SelectedPath);
                    tbAppointment.Text = d.FullName;
                    LoadFiles(tbSource.Text);
                }
            }            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {    
            if((String.IsNullOrEmpty(tbAppointment.Text) == false) && (String.IsNullOrEmpty(tbSource.Text) == false))
            {
                t1.Start(max);
                t2.Start();                
                return;
            }
            System.Windows.MessageBox.Show("Select paths");
            
        }

        private void StartCopy()
        {
            //this.Dispatcher.Invoke(() => LoadFiles(tbSource.Text));
            this.Dispatcher.Invoke(() => CopyFiles(tbSource.Text, tbAppointment.Text)); 
        }

        private void CopyFiles(string sourceDir, string destDir)
        {
            foreach (var item in files)
            {
                string fileName = item.Substring(sourceDir.Length+1);
                File.Copy(System.IO.Path.Combine(sourceDir, fileName),
                            System.IO.Path.Combine(destDir, fileName), true);
            }   
        }
    }
}
