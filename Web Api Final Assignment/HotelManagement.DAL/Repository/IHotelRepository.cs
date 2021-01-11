using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models;

namespace HotelManagement.DAL.Repository
{
    public interface IHotelRepository
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
