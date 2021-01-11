using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelManagement.Models;

namespace HotelManagement.BAL.Interface
{
    public interface IHotelManager
    {
        string createHotel(Hotel model);
        //Hotel getHotel();
       Hotel getHotelById(int id);
        List<Hotel> getAllHotels();
        IQueryable getAllRoomsByParameter(Hotel model);

        List<Booking> checkAvailability(Booking model);

        string createRoom(Room model);
      
        string bookRoom(Booking model);
       string updateBookingDate(Booking model);
        string updateBookingStatus(Booking model);
        string deleteBooking(int id);

    }
}
