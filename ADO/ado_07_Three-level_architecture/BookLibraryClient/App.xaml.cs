using Autofac;
using Booklibrary.DAL.Repository;
using BookLibrary.BLL.Servises;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BookLibraryClient
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private static IContainer container;
        public App()
        {
            //var builder = new ContainerBuilder();

            ////builder.RegisterType<AppContext>().As<DbContext>().SingleInstance();
            //builder.RegisterGeneric(typeof(EFRepo<>)).As(typeof(IGenericRepo<>));
            //builder.RegisterType<BookService>().As<IBookService>();

            //container = builder.Build();
        }
        
    }
}
