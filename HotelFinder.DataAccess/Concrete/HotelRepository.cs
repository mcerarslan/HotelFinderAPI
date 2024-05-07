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
    }
}
