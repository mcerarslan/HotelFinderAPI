using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Abstract
{
    public interface IHotelService : IRepositoryServices<Hotel>
    {
        IEnumerable<Hotel> TGetByName(string name);
    }
}
