using HotelFinder.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected HotelDbContext _context;
        private DbSet<T> _dbSet;
 
        public Repository(HotelDbContext context) 
        {
            
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Delete(int id)
        { 
            _dbSet.Remove(GetById(id));
            _context.SaveChanges();
        }

       

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            _context.ChangeTracker.Clear();
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
             _context.ChangeTracker.Clear();
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
    }
}
