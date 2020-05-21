using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPF_04
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (video.Source != null)
            {
                if (video.NaturalDuration.HasTimeSpan)
                {
                    lblStatus.Content = String.Format("{0} / {1}", video.Position.ToString(@"mm\:ss"), video.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
                    //timelineSlider.Value = video.Position;
                }
                    
            }            
        }
        private void Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == true)
            {
                video.Source = new Uri(fd.FileName);
                playList.Items.Add(fd.FileName);
            }
                
            
        }
        private void Play(object sender, RoutedEventArgs e)
        {
            video.Play();
        }

        private void Stop(object sender, RoutedEventArgs e)
        {
            video.Stop();
        }

        private void Mute(object sender, RoutedEventArgs e)
        {
            video.Volume = 0;
        }
        private void video_MediaOpened(object sender, RoutedEventArgs e)
        {
            timelineSlider.Maximum = video.NaturalDuration.TimeSpan.TotalSeconds;
        }

        private void timelineSlider_LostMouseCapture(object sender, MouseEventArgs e)
        {
            TimeSpan time = new TimeSpan(0, 0, Convert.ToInt32(Math.Round(timelineSlider.Value))); //отлавливаем позицию на которую нужно перемотать трек
            video.Position = time; //устанавливаем новую позицию для трека
        }
    }
}
