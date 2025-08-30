using HotelBooking.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.BLL.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAllAsync();
        Task<RoomDto?> GetByIdAsync(int id);
        Task<RoomDto> AddAsync(RoomDto dto);
        Task<RoomDto?> UpdateAsync(RoomDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
