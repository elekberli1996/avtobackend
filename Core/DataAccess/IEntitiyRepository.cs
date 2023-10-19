using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntitiyRepository <T>
    {
        void Add(T entity);
        void Delete(T entitiy);

        void Update(T entitiy);

        T Get(Expression<Func<T, bool>> filter);

        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        bool SaveChanges();
    }
}
