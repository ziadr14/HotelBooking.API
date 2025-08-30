using HotelBooking.DAL.Data;
using HotelBooking.DAL.Interfaces;
using HotelBooking.DAL.Models;
using HotelBookingDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DAL.Repository
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(AppDbContext context) : base(context) { }
    }
}
