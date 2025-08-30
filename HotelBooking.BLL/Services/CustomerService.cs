using AutoMapper;
using HotelBooking.BLL.DTOs;
using HotelBooking.BLL.Interfaces;
using HotelBooking.DAL.Interfaces;
using HotelBooking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingBLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IBaseRepository<Customer> _customerRepo;
        private readonly IMapper _mapper;

        public CustomerService(IBaseRepository<Customer> customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            try
            {
                var customers = _customerRepo.GetAllAsync();
                return _mapper.ProjectTo<CustomerDto>(customers).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving customers", ex);
            }
        }

        public async Task<CustomerDto?> GetByIdAsync(int id)
        {
            try
            {
                var customer = await _customerRepo.GetByIdAsync(id);
                return customer == null ? null : _mapper.Map<CustomerDto>(customer);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving customer", ex);
            }
        }

        public async Task<CustomerDto> AddAsync(CustomerDto dto)
        {
            try
            {
                var customer = _mapper.Map<Customer>(dto);
                await _customerRepo.AddAsync(customer);
                await _customerRepo.SaveChangesAsync();
                return _mapper.Map<CustomerDto>(customer);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding customer", ex);
            }
        }

        public async Task<CustomerDto?> UpdateAsync(CustomerDto dto)
        {
            try
            {
                var existing = await _customerRepo.GetByIdAsync(dto.Id);
                if (existing == null) return null;

                _mapper.Map(dto, existing);
                await _customerRepo.UpdateAsync(existing);
                await _customerRepo.SaveChangesAsync();

                return _mapper.Map<CustomerDto>(existing);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating customer", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var customer = await _customerRepo.GetByIdAsync(id);
                if (customer == null) return false;

                await _customerRepo.DeleteAsync(customer);
                await _customerRepo.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting customer", ex);
            }
        }
    }
}
