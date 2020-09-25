using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.DAL.Repository
{
    public interface IGenericRepository<T_entity> where T_entity : class
    {
        void Create(T_entity entity);
        void Update(T_entity entity);
        void Delete(T_entity entity);
        IEnumerable<T_entity> GetAll();
    }
}
