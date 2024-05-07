using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        [HttpGet]
        public  IActionResult GetHotels()
        {
            var hotels =  _hotelService.TGetAll();
            return Ok(hotels);

        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetHotelById(int id)
        {   
            var hotel =  _hotelService.TGetById(id);
            if (hotel != null) 
            {
                return Ok(hotel);
            }
            
            return NotFound();

        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetHotelByNameAndCity(string name, string city)
        {

            var hotels = _hotelService.TGet(new List<Expression<Func<Hotel, bool>>>
            {
                 h => h.Name == name && h.City == city
            }).ToList();
            return Ok(hotels);
        }


        [HttpGet]
        [Route("[action]/{city}")]
        public IActionResult GetHotelByCity(string city)
        {
          
            var hotels = _hotelService.TGet(new List<Expression<Func<Hotel,bool>>>
            {
                h => h.City.StartsWith(city)
            });
            return Ok(hotels);
        }

        [HttpPost]
        public IActionResult CreateHotel([FromBody]Hotel hotel)
        {
            _hotelService.TInsert(hotel);
             return Ok();


        }

        [HttpPut]
        public IActionResult Put([FromBody] Hotel hotel)
        {
        
            if ( _hotelService.TGetById(hotel.Id) != null)
            {
                _hotelService.TUpdate(hotel);
                return Ok();
            }
            return NotFound();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if ( _hotelService.TGetById(id) != null)
            {
                _hotelService.TDelete(id);
                return Ok();
            }
            return NotFound();


        }

    }
}
