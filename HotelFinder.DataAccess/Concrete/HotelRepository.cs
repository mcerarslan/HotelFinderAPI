using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        public HotelRepository(HotelDbContext context) : base(context)
        {
        }

        public IEnumerable<Hotel> GetByName(string name)
        {
   
            return _context.Set<Hotel>().Where(u => u.Name.Replace(" ","").ToLower().Contains(name.Replace(" ", "").ToLower())).ToList();
        }
    }
}
