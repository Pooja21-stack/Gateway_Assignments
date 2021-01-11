using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelManagement.BAL.Interface;
using HotelManagement.Models;

namespace Hotel_Management.Controllers
{
    public class HotelController : ApiController
    {
        private readonly IHotelManager _HotelManager;

        public HotelController()
        {

        }

        public HotelController(IHotelManager HotelManager)
        {
            _HotelManager = HotelManager;
        }
        // GET: api/Hotel
        
      public List<Hotel> getAllHotels()
      {
          //return new string[] { "value1", "value2" };
          return _HotelManager.getAllHotels();
      }
        
      // GET: api/Hotel/5
      
      public Hotel getHotelById(int id)
      {
          return _HotelManager.getHotelById(id);
      }

       
        //Create Room
        // POST: api/Hotel
       
        public string createRoom([FromBody] Room model)
        {
            return _HotelManager.createRoom(model);
        }
       

        //get rooms by parameters
        // GET: api/Hotel/5
        
        public IQueryable getAllRoomsByParameter([FromBody]Hotel model)
        {
            return _HotelManager.getAllRoomsByParameter(model);
        }
        
        //Book Room
        // POST: api/Hotel
        
        public string bookRoom([FromBody] Booking model)
        {
            return _HotelManager.bookRoom(model);
        }
         
        // POST: api/Hotel
        
        public string Post([FromBody]Hotel model)
        {
            return _HotelManager.createHotel(model);

        }
       
        
        // PUT: api/Hotel/5
        
        [HttpPut]
        public string updateBookingStatus([FromBody]Booking model)
        {
            return _HotelManager.updateBookingStatus(model);    
        }

        
        
        [HttpPut]
        public string updateBookingDate([FromBody] Booking model)
        {
            return _HotelManager.updateBookingDate(model);
        }
       
        
        //get availability of Rooms
        
        
        
        [HttpPost]
        public List<Booking> checkAvailability([FromBody] Booking model)
        {

            return _HotelManager.checkAvailability(model);
        }
     
        
        
        // DELETE: api/Hotel/5
        public string Delete(int id)
        {
            return _HotelManager.deleteBooking(id);
        }
    }
}
