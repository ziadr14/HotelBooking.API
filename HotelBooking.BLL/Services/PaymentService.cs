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
    public class PaymentService : IPaymentService
    {
        private readonly IBaseRepository<Payment> _paymentRepo;
        private readonly IMapper _mapper;

        public PaymentService(IBaseRepository<Payment> paymentRepo, IMapper mapper)
        {
            _paymentRepo = paymentRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentDto>> GetAllAsync()
        {
            try
            {
                var payments = _paymentRepo.GetAllAsync();
                return _mapper.ProjectTo<PaymentDto>(payments).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving payments", ex);
            }
        }

        public async Task<PaymentDto?> GetByIdAsync(int id)
        {
            try
            {
                var payment = await _paymentRepo.GetByIdAsync(id);
                return payment == null ? null : _mapper.Map<PaymentDto>(payment);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving payment", ex);
            }
        }

        public async Task<PaymentDto> AddAsync(PaymentDto dto)
        {
            try
            {
                var payment = _mapper.Map<Payment>(dto);
                await _paymentRepo.AddAsync(payment);
                await _paymentRepo.SaveChangesAsync();
                return _mapper.Map<PaymentDto>(payment);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding payment", ex);
            }
        }

        public async Task<PaymentDto?> UpdateAsync(PaymentDto dto)
        {
            try
            {
                var existing = await _paymentRepo.GetByIdAsync(dto.Id);
                if (existing == null) return null;

                _mapper.Map(dto, existing);
                await _paymentRepo.UpdateAsync(existing);
                await _paymentRepo.SaveChangesAsync();

                return _mapper.Map<PaymentDto>(existing);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating payment", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var payment = await _paymentRepo.GetByIdAsync(id);
                if (payment == null) return false;

                await _paymentRepo.DeleteAsync(payment);
                await _paymentRepo.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting payment", ex);
            }
        }
    }
}
