using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Abstract
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        IQueryable<T> Get(List<Expression<Func<T, bool>>> predicate);

        void Insert(T entity);

        void Update(T entity);
        void Delete(int id);

    }
}
