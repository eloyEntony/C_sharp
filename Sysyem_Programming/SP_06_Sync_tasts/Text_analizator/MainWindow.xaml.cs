using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Text_analizator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }
        Task<string> t1;
        Task<string> t2;
        Task<string> t3;
        Task<string> t4;
        Task<string> t5;
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
        }

        private void AnalizeTextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tbText.Text))
                return;

            t1 = new Task<string>(GetCountWords, tbText.Text);
            t2 = new Task<string>(GetCountRows, tbText.Text);
            t3 = new Task<string>(GetCountCharacters, tbText.Text);
            t4 = new Task<string>(GetCountExclamation, tbText.Text);
            t5 = new Task<string>(GetCountInterrogative, tbText.Text);

            lbres.Items.Clear();
            pBar.Value = 0;
            Progress(null);

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();

            Task.WaitAll(t5);

            lbres.Items.Add(t1.Result);
            lbres.Items.Add(t2.Result);
            lbres.Items.Add(t3.Result);
            lbres.Items.Add(t4.Result);
            lbres.Items.Add(t5.Result);
        }

        static public string GetCountWords(object state)
        {
            int count = (state as string).Split(' ').Length;
            return "Word => " + count;
        }

        static public string GetCountRows(object state)
        {
            int count = (state as string).Split('.', '!', '?').Length - 1;
            return "Rows => " + count;
        }

        static public string GetCountCharacters(object state)
        {
            int count = (state as string).Length;
            return "Characters => " + count;
        }

        static public string GetCountExclamation(object state)
        {
            int count = (state as string).Split('!').Length - 1;
            return "Exclamation => " + count;
        }

        static public string GetCountInterrogative(object state)
        {
            int count = (state as string).Split('?').Length - 1;
            return "Interrogative => " + count;
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            lbres.Items.Clear();

            lbres.Items.Add(t1.Result);
            lbres.Items.Add(t2.Result);
            lbres.Items.Add(t3.Result);
            lbres.Items.Add(t4.Result);
            lbres.Items.Add(t5.Result);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            using (TextWriter tw = new StreamWriter("result.txt"))
            {
                foreach (var item in lbres.Items)
                    tw.WriteLine(item);
            }
        }

        static public void Progress(object state)
        {
            for (int i = 0; i < 100; i++)
            {
                Instance.Dispatcher.Invoke(() => { Instance.pBar.Value = i; });
                Thread.Sleep(10);
            }
        }
    }
}
