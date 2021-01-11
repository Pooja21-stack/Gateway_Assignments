using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelManagement.Models
{
   public  class Room
    {
        public int RoomId { get; set; }
        public Nullable<int> HotelId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }


       
    }
}
