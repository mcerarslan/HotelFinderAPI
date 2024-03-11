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
        private IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var hotels = await _hotelService.GetHotels();
            return Ok(hotels);

        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {   
            var hotel = await  _hotelService.GetHotelById(id);
            if (hotel != null) 
            {
                return Ok(hotel);
            }
            
            return NotFound();

        }
        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetHotelByName(string name)
        {
            var hotel = await _hotelService.GetHotelByName(name);
            if(hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();


        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Hotel hotel)
        {
            var CreatedHotel = await _hotelService.CreateHotel(hotel);
            return CreatedAtAction("Get", new {id  = CreatedHotel.Id}, CreatedHotel);

        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Hotel hotel)
        {
            if (await _hotelService.GetHotelById(hotel.Id) != null)
            {
                return Ok(await _hotelService.UpdateHotel(hotel));
            }
            return NotFound();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _hotelService.GetHotelById(id) != null)
            {
                await _hotelService.DeleteHotelById(id);
                return Ok();
            }
            return NotFound();
           

        }
    }
}
