using HotelFinder.Business.Abstract;
using HotelFinder.DataAccess;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Concrete
{
    public class HotelManager : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelManager(IHotelRepository hotelRepository) 
        { 
            _hotelRepository = hotelRepository;

        }

        public IEnumerable<Hotel> TGetByName(string name)
        {
            return _hotelRepository.GetByName(name);
        }

        public void TDelete(int id)
        {
            _hotelRepository.Delete(id);
        }

        public IEnumerable<Hotel> TGetAll()
        {
             return  _hotelRepository.GetAll();
        }

        public Hotel TGetById(int id)
        {
            if (id > 0)
            {
                return _hotelRepository.GetById(id);

            }
            throw new Exception("id can not be less than 1");
             
        }

        public void TInsert(Hotel entity)
        {
             _hotelRepository.Insert(entity);
        }

        public void TUpdate(Hotel entity)
        {    
            _hotelRepository.Update(entity);
        }

        Hotel IRepositoryServices<Hotel>.TInsert(Hotel entity)
        {
            throw new NotImplementedException();
        }

       
    }
}
