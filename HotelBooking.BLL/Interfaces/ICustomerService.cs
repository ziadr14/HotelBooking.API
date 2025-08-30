using HotelBooking.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.BLL.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CustomerDto?> GetByIdAsync(int id);
        Task<CustomerDto> AddAsync(CustomerDto dto);
        Task<CustomerDto?> UpdateAsync(CustomerDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
