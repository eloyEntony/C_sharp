using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.DAL.Repository
{
    public class EF_Repository<T_entity> : IGenericRepository<T_entity> where T_entity : class
    {
        private readonly DbContext context;
        private readonly DbSet<T_entity> set;
        public EF_Repository(DbContext _context)
        {
            context = _context;
            set = context.Set<T_entity>();
        }
        public void Create(T_entity entity)
        {
            set.Add(entity);
            context.SaveChanges();
        }

        public void Delete(T_entity entity)
        {
            set.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<T_entity> GetAll()
        {
            return set.AsEnumerable();
        }

        public void Update(T_entity entity)
        {
            context.Set<T_entity>().AddOrUpdate(entity);
            context.SaveChanges();
        }
    }
}
