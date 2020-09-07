using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklibrary.DAL.Repository
{
    public class EFRepo<TEntity> : IGenericRepo<TEntity> where TEntity:class
    {
        private readonly DbContext context;

        public EFRepo()
        {
            
        }

        public void Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().AsEnumerable();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            //context.Set<TEntity>().AddOrUpdate(entity);
            context.SaveChanges();
        }
    }
}
