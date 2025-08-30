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
    public class ReservationService : IReservationService
    {
        private readonly IBaseRepository<Reservation> _reservationRepo;
        private readonly IMapper _mapper;

        public ReservationService(IBaseRepository<Reservation> reservationRepo, IMapper mapper)
        {
            _reservationRepo = reservationRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReservationDto>> GetAllAsync()
        {
            try
            {
                var reservations = _reservationRepo.GetAllAsync();




                return _mapper.ProjectTo<ReservationDto>(reservations).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving reservations", ex);
            }
        }

        public async Task<ReservationDto?> GetByIdAsync(int id)
        {
            try
            {
                var reservation = await _reservationRepo.GetByIdAsync(id);
                return reservation == null ? null : _mapper.Map<ReservationDto>(reservation);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving reservation", ex);
            }
        }

        public async Task<ReservationDto> AddAsync(ReservationDto dto)
        {
            try
            {
                var reservation = _mapper.Map<Reservation>(dto);
                await _reservationRepo.AddAsync(reservation);
                await _reservationRepo.SaveChangesAsync();
                return _mapper.Map<ReservationDto>(reservation);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding reservation", ex);
            }
        }

        public async Task<ReservationDto?> UpdateAsync(ReservationDto dto)
        {
            try
            {
                var existing = await _reservationRepo.GetByIdAsync(dto.Id);
                if (existing == null) return null;

                _mapper.Map(dto, existing);
                await _reservationRepo.UpdateAsync(existing);
                await _reservationRepo.SaveChangesAsync();

                return _mapper.Map<ReservationDto>(existing);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating reservation", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var reservation = await _reservationRepo.GetByIdAsync(id);
                if (reservation == null) return false;

                await _reservationRepo.DeleteAsync(reservation);
                await _reservationRepo.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting reservation", ex);
            }
        }
    }
}
