using HotelBooking.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.BLL.Interfaces
{
    public interface IReservationService
    {
            
        Task<IEnumerable<ReservationDto>> GetAllAsync();
        Task<ReservationDto?> GetByIdAsync(int id);
        Task<ReservationDto> AddAsync(ReservationDto dto);
        Task<ReservationDto?> UpdateAsync(ReservationDto dto);
        Task<bool> DeleteAsync(int id);
    
}
}
