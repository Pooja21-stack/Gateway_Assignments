using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagement.BAL.Interface;
using HotelManagement.DAL.Repository;
using HotelManagement.Models;

namespace HotelManagement.BAL
{
    public class HotelManager : IHotelManager
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        
        
        public string bookRoom(Booking model)
        {
            return _hotelRepository.bookRoom(model);
        }
          
        
        public List<Booking> checkAvailability(Booking model)
        {
            return _hotelRepository.checkAvailability(model);
        }
      
        
        public string createHotel(Hotel model)
        {
            return _hotelRepository.createHotel(model);
        }
        
        
        public string deleteBooking(int id)
        {
            return _hotelRepository.deleteBooking(id);
        }
        
        
    public List<Hotel> getAllHotels()
    {
        var hotel=  _hotelRepository.getAllHotels();
        return hotel;
    }
        
      
       
    public Hotel getHotelById(int id)
    {
        return _hotelRepository.getHotelById(id);
    }
    
        
        public string createRoom(Room model)
        {
            return _hotelRepository.createRoom(model);
        }
        
        
        public IQueryable getAllRoomsByParameter(Hotel model)
        {
            return _hotelRepository.getAllRoomsByParameter(model);
        }
        
        
        
        public string updateBookingDate(Booking model)
        {
            return _hotelRepository.updateBookingDate(model);
        }
        
    
        
        public string updateBookingStatus(Booking model)
        {
            return _hotelRepository.updateBookingStatus(model);
        }
        
    }

}
