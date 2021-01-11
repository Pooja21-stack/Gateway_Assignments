using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
   public class Booking
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public Nullable<int> RoomId { get; set; }
        public string StatusOfBooking { get; set; }

       
    }
}
