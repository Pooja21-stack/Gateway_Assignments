using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models;

namespace HotelManagement.DAL.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly Database.db_testEntities dbContext;
        public HotelRepository()
        {
            dbContext = new Database.db_testEntities();
        }

        // POST Booked the room of hotel for particular date with (optional status)
        
        public string bookRoom(Booking model)
        {
            try
            {
                if(model != null)
                {
                    var entity = dbContext.tbl_room.Find(model.RoomId);

                    Database.tbl_room room = new Database.tbl_room();

                    Database.tbl_booking booking = new Database.tbl_booking();

                    booking.BookingDate = model.BookingDate;
                    booking.RoomId = model.RoomId;
                    booking.StatusOfBooking = "Definitive";

                    entity.IsActive = true;

                    dbContext.tbl_booking.Add(booking);
                    dbContext.SaveChanges();
                    return "Booked Successfully";
                }
                return "Model is empty";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        
        public List<Booking> checkAvailability(Booking model)
        {
            List<Booking> booking = new List<Booking>();
            var room = dbContext.tbl_room.ToList();
            if(room != null)
            {
                foreach (var item in room)
                {
                    var entity = dbContext.tbl_booking.Where(b => b.RoomId == item.RoomId && b.BookingDate == model.BookingDate);
                    if(entity.Count() != 0)
                    {
                        foreach(var data in entity)
                        {
                            Room r = new Room();   
                            if (data.StatusOfBooking == "Deleted")
                            {
                                r.IsActive = true;  
                            }
                            else
                            {
                                r.IsActive = false;
                            }
                            
                        }
                        
                    }
                }
               
            }
            return booking;
        }
        


        //POST 5-10 hotels with details of hotel and 3-5 rooms in each hotel with different price and different category.
        
        public string createHotel(Hotel model)
        {
            try
            {
                if (model != null)
                {
                    Database.tbl_hotel entity = new Database.tbl_hotel();
                    entity.Name = model.Name;
                    entity.City = model.City;
                    entity.ContactNumber = model.ContactNumber;
                    entity.Address = model.Address;
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = model.CreatedBy;
                    entity.PinCode = model.PinCode;
                    entity.Twitter = model.Twitter;
                    entity.Facebook = model.Facebook;
                    entity.Website = model.Website;
                    entity.ContactPerson = model.ContactPerson;
                    entity.IsActive = true;
                        
                    dbContext.tbl_hotel.Add(entity);
                    dbContext.SaveChanges();

                    return "Successfully Added";
                }
                return "Model is null";

            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        

        //Post 3-5 rooms in each hotel with different price and different category.



        public string createRoom( Room model)
        {
            try
            {
                
                if (model != null)
                {
                   
                     Database.tbl_room entity = new Database.tbl_room();
                    
                    entity.HotelId = model.HotelId;
                    entity.Name = model.Name;
                    entity.Category = model.Category;
                    entity.Price = model.Price;
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = model.CreatedBy;
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = model.UpdatedBy;
                    entity.IsActive = true;
                 
                    dbContext.tbl_room.Add(entity);
                    dbContext.SaveChanges();

                    return "Successfully Added";

                }
                return "Model is null";
            }
            catch(Exception ex)
            {
                throw ex;
              // return ex.Message;
            }
        }
        
        

        //DELETE delete booking by booking Id (change status Deleted – soft delete)
        public string deleteBooking(int BookingId)
        {
            try
            {
                var entity = dbContext.tbl_booking.Find(BookingId);
                var entities = dbContext.tbl_room.Find(entity.RoomId);
                if (entity != null)
                {

                   // dbContext.tbl_booking.Remove(entity);
                    entity.StatusOfBooking = "Deleted";
                    entities.IsActive = false;
                    dbContext.SaveChanges();
                    return "Soft Deleted";
                }
                return "No data found";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        //GET all hotels sort by alphabetic order. Response: List of hotels 
        
       public List<Hotel> getAllHotels()
       {
           List<Hotel> list = new List<Hotel>();
           var entities = dbContext.tbl_hotel.OrderBy(model => model.Name).ToList();

           if (entities != null)
           {
               foreach(var item in entities)
               {
                   Hotel hotel = new Hotel();
                   hotel.HotelId = item.HotelId;
                   hotel.Name = item.Name;
                   hotel.Address = item.Address;
                   hotel.City = item.City;
                   hotel.PinCode = item.PinCode;
                   hotel.Twitter = item.Twitter;
                   hotel.Facebook = item.Facebook;
                   hotel.Website = item.Website;
                   hotel.CreatedDate = item.CreatedDate;
                   hotel.CreatedBy = item.CreatedBy;
                   hotel.UpdatedDate = item.UpdatedDate;
                   hotel.UpdatedBy = item.UpdatedBy;
                   hotel.ContactNumber = item.ContactNumber;
                   hotel.IsActive = item.IsActive;

                   list.Add(hotel);

               }
           }
           return list;
       }
        
       //Get hotel by id
       
       public Hotel getHotelById(int id)
       {
           try
           {
               var item = dbContext.tbl_hotel.Find(id);
               if(item != null)
               {
                   Hotel hotel = new Hotel();
                   hotel.HotelId = item.HotelId;
                   hotel.Name = item.Name;
                   hotel.Address = item.Address;
                   hotel.City = item.City;
                   hotel.PinCode = item.PinCode;
                   hotel.Twitter = item.Twitter;
                   hotel.Facebook = item.Facebook;
                   hotel.Website = item.Website;
                   hotel.CreatedDate = item.CreatedDate;
                   hotel.CreatedBy = item.CreatedBy;
                   hotel.UpdatedDate = item.UpdatedDate;
                   hotel.UpdatedBy = item.UpdatedBy;
                   hotel.ContactNumber = item.ContactNumber;
                   hotel.IsActive = item.IsActive;

                   return hotel;
               }
               return null;
           }
           catch(Exception ex)
           {
               throw ex;
           }
       }
       
       
        public IQueryable getAllRoomsByParameter(Hotel model)
        {
            var rooms = from hotel in dbContext.tbl_hotel
                        join room in dbContext.tbl_room on hotel.HotelId equals room.HotelId
                        where hotel.City == model.City || hotel.PinCode == model.PinCode
                        orderby room.Price
                        select new
                        {
                            hotel.HotelId,
                            room.RoomId,
                            room.Name,
                            room.Category,
                            room.Price,
                            hotel.PinCode,
                            hotel.City
                        };
            return rooms;

        }
       

        // PUT update booking date for any room by Id
        
        public string updateBookingDate(Booking model)
        {
            try
            {
                var entity = dbContext.tbl_booking.Find(model.BookingId);
                if(entity != null)
                {
                    entity.BookingDate = model.BookingDate;
                    dbContext.SaveChanges();
                    return "Updated";
                }
                return "No data found";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        
        //PUT update booking status by booking Id(optional status to Definitive or Cancelled)
        public string updateBookingStatus(Booking model)
        {
            try
            {
                var entity = dbContext.tbl_booking.Find(model.BookingId);
                if (entity != null)
                {
                    entity.StatusOfBooking = model.StatusOfBooking;
                    dbContext.SaveChanges();
                    return "Updated";
                }
                return "No data found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
    }
}
