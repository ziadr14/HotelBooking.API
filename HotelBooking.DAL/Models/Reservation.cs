using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DAL.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Payment? Payment { get; set; }
    }
}
