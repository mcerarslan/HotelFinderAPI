using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [Route("[action]/{name}")]
        public  IActionResult GetHotelByName(string name)
        {
            var hotel = _hotelService.TGetByName(name);
            if(hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();

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
