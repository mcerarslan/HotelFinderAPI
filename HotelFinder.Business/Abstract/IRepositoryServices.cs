using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Abstract
{
    public interface IRepositoryServices<T> where T : class
    {
        IEnumerable<T> TGetAll();

        T TGetById(int id);
     

        T TInsert(T entity);

        void TUpdate(T entity);
        void TDelete(int id);
    }
}
