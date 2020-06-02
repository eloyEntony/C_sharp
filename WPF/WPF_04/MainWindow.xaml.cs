using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace WPF_04
{
    public partial class MainWindow : Window
    {
        List<string> allFile = new List<string>();
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
            if (video.Source != null && video.NaturalDuration.HasTimeSpan)
            {
                timelineSlider.Minimum = 0;
                lblStatus.Content = String.Format("{0} / {1}", video.Position.ToString(@"mm\:ss"), video.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
                timelineSlider.Value = video.Position.TotalSeconds;

            }
        }
        private void Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            string name;
            if (fd.ShowDialog() == true)
            {
                video.Source = new Uri(fd.FileName);
                allFile.Add(fd.FileName);
                playList.Items.Add(name = playList.Items.Count + 1 + ". |   " + System.IO.Path.GetFileName(fd.FileName));
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

        private void playList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            video.Source = new Uri(allFile[playList.SelectedIndex]);
        }

    }
}
