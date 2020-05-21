using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

 /* Paint:
    Режими малювання RadioButtons
            combobox для вибору ширини ліній
    combobox для вибору кольору
            кнопки зберегти\відкрити - реалізація за допомогою діалогових вікон
*/

namespace WPF_02
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ink.DefaultDrawingAttributes.Color = Colors.Red;
            ink.DefaultDrawingAttributes.Width = 10;
            ink.DefaultDrawingAttributes.Height = 10;

            for (int i = 8; i < 72; i++)
            {
                cbSize.Items.Add(i);
                i += 2;
            }

            paintRB.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ink.EditingMode = InkCanvasEditingMode.EraseByStroke;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ink.EditingMode = InkCanvasEditingMode.GestureOnly;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ink.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string color = (cbColor.SelectedItem as Label).Content.ToString();
            ink.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(color);
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "STR file(*.str)|*.str";
            sfd.OverwritePrompt = true;
            sfd.FileName = "New document";

            if(sfd.ShowDialog() == true)
                ink.Strokes.Save(new FileStream(sfd.FileName, FileMode.Create));
           
        }

        private void Button_Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "STR file(*.str)|*.str";
            fd.FileName = "Type name here";
            if (fd.ShowDialog() == true)
            {
                StrokeCollection strokes = new StrokeCollection(new FileStream(fd.FileName, FileMode.Open));
                ink.Strokes = strokes;
            }
            
        }

        private void cbSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var size = Convert.ToDouble(cbSize.SelectedItem);
            ink.DefaultDrawingAttributes.Width = ink.DefaultDrawingAttributes.Height = size;

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if ((string)radioButton.Content == "Erase")
                ink.EditingMode = InkCanvasEditingMode.EraseByStroke;
            else if((string)radioButton.Content == "Gesture")
                ink.EditingMode = InkCanvasEditingMode.GestureOnly;
            else if ((string)radioButton.Content == "Paint")
                ink.EditingMode = InkCanvasEditingMode.Ink;

        }
    }
}
