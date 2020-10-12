using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
using TanksLib;

namespace TankApp
{
    public partial class MainWindow : Window
    {
        static List<Tank> T_34 = new List<Tank>();
        static List<Tank> Pantera = new List<Tank>();
        static ObservableCollection<string> winer = new ObservableCollection<string>();
        static string t34 = "../../images/1.png";
        static string pantera = "../../images/2.png";
        static string fail = "../../images/fail.png";
        static Uri uri1 = new Uri(t34, UriKind.Relative);
        static Uri uri2 = new Uri(pantera, UriKind.Relative);
        static Uri uriFail = new Uri(fail, UriKind.Relative);

        static BitmapImage Image1 = new BitmapImage(uri1);
        static BitmapImage Image2 = new BitmapImage(uri2);
        static BitmapImage Image3 = new BitmapImage(uriFail);
        public static MainWindow Instance { get; private set; }
        static int t34WinCount = 0;
        static int panteraWinCount = 0;


        public MainWindow()
        {
            InitializeComponent();
            lb.ItemsSource = winer;
            i1.Source = Image1;
            i2.Source = Image2;
            Instance = this;

            Create();
            Start();

        }

        private  static void CheckRes()
        {
            Instance.lbWiner.Content = $"T-34 ( {t34WinCount} - {panteraWinCount} ) Pantera";
            if (t34WinCount > panteraWinCount)                           
                Instance.imgWiner.Source = Image1;
            else 
                Instance.imgWiner.Source = Image2;
        }

        private static void Result(string tank)
        {
            if (tank.Contains("34"))
                t34WinCount++;
            else
                panteraWinCount++;
        }

        static async void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                Instance.lbWiner.Content = $"T-34 ( {t34WinCount} - {panteraWinCount} ) Pantera";
                string res = (await Fight(i)).GetName();
                ChangeImage(res);                
                winer.Add(res);
                Result(res);
            }
            CheckRes();
            Instance.Dispatcher.Invoke(() => { Instance.i1.Source = Image1; });
            Instance.Dispatcher.Invoke(() => { Instance.i2.Source = Image2; });
        }
        public static void ChangeImage(string tank)
        {
            if (tank.Contains("34"))            
                Instance.i2.Source = Image3;            
            else
                Instance.i1.Source = Image3;
        }
        public void Create()
        {
            for (int i = 0; i < 5; i++)
            {
                T_34.Add(new Tank($"T-34 [{i}]"));
                Pantera.Add(new Tank($"Pantera [{i}]"));
            }
        }
        private async static Task<Tank> Fight(int i)
        {            
            return await Task.Run(() =>
            {
                Thread.Sleep(2000);
                Progres();
                return T_34[i] ^ Pantera[i];
            });
        }

        public static void Progres()
        {
            Instance.Dispatcher.Invoke(() => { Instance.i1.Source = Image1; });
            Instance.Dispatcher.Invoke(() => { Instance.i2.Source = Image2; });           
            
            for (int i = 0; i < 100; i++)
            {
                Instance.Dispatcher.Invoke(() => { Instance.progess.Value = i; });
                Thread.Sleep(10);
            }
        }
    }
}
