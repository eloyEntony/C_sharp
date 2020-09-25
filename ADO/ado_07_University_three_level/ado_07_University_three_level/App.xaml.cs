using Autofac;
using AutoMapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using University.BLL.Services;
using University.BLL.Utils;
using University.DAL;
using University.DAL.Repository;

namespace ado_07_University_three_level
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AppContext>().As<DbContext>().SingleInstance();
            builder.RegisterGeneric(typeof(EF_Repository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterType<StudentService>().As<IStudentService>();
            builder.RegisterType<GroupService>().As<IGroupService>();
            builder.RegisterType<MainWindow>().AsSelf();

            var config = new MapperConfiguration(cgf => cgf.AddProfile(new MapperConfig()));
            builder.RegisterInstance(config.CreateMapper());

            using (var scope = builder.Build().BeginLifetimeScope())
            {
                var window = scope.Resolve<MainWindow>();
                window.ShowDialog();
            }
        }
    }
}
