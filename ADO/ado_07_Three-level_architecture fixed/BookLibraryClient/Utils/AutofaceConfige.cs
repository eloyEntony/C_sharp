using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booklibrary.DAL;
using Booklibrary.DAL.Repository;
using System.Data.Entity;

namespace BookLibraryClient.Utils
{
    class AutofaceConfige
    {
        public AutofaceConfige()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Booklibrary.DAL.AppContext>().As<DbContext>();
            builder.RegisterGeneric(typeof(EFRepo<>)).As(typeof(IGenericRepo<>));


        }
    }
}
