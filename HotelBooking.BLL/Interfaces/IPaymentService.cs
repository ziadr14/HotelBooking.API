using HotelBooking.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.BLL.Interfaces
{
    public interface IPaymentService
    {

            Task<IEnumerable<PaymentDto>> GetAllAsync();
            Task<PaymentDto?> GetByIdAsync(int id);
            Task<PaymentDto> AddAsync(PaymentDto dto);
            Task<PaymentDto?> UpdateAsync(PaymentDto dto);
            Task<bool> DeleteAsync(int id);
        
    }
}
