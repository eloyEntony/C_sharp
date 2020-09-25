using Autofac;
using Booklibrary.DAL;
using Booklibrary.DAL.Repository;
using BookLibrary.BLL.Model;
using BookLibrary.BLL.Servises;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace BookLibraryClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private readonly IBookService service;


        public MainWindow()
        {
            InitializeComponent();
            service = new BookService();
            this.DataContext.ItemsSource = service.GetBooks().ToList();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BookDTO book = new BookDTO
            {
                Title = "C#",
                Price = 300, 
                Year= 2020, 
                Author = "Bob",
                Genre = "Fanazy"
            };
            service.AddBook(book);
        }
    }
}
