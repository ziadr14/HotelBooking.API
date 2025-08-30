using AutoMapper;
using HotelBooking.BLL.DTOs;
using HotelBooking.BLL.Interfaces;
using HotelBooking.DAL.Interfaces;
using HotelBooking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingBLL.Services
{
    public class RoomService : IRoomService
    {
        private readonly IBaseRepository<Room> _roomRepo;
        private readonly IMapper _mapper;

        public RoomService(IBaseRepository<Room> roomRepo, IMapper mapper)
        {
            _roomRepo = roomRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomDto>> GetAllAsync()
        {
            try
            {
                var rooms =  _roomRepo.GetAllAsync();
                return _mapper.Map<IEnumerable<RoomDto>>(rooms);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching rooms", ex);
            }
        }

        public async Task<RoomDto?> GetByIdAsync(int id)
        {
            try
            {
                var room = await _roomRepo.GetByIdAsync(id);
                return room == null ? null : _mapper.Map<RoomDto>(room);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while fetching room with ID {id}", ex);
            }
        }

        public async Task<RoomDto> AddAsync(RoomDto dto)
        {
            try
            {
                var room = _mapper.Map<Room>(dto);
                await _roomRepo.AddAsync(room);
                await _roomRepo.SaveChangesAsync();
                return _mapper.Map<RoomDto>(room);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding room", ex);
            }
        }

        public async Task<RoomDto?> UpdateAsync(RoomDto dto)
        {
            try
            {
                var existingRoom = await _roomRepo.GetByIdAsync(dto.Id);
                if (existingRoom == null) return null;

                _mapper.Map(dto, existingRoom);
                await _roomRepo.UpdateAsync(existingRoom);
                await _roomRepo.SaveChangesAsync();

                return _mapper.Map<RoomDto>(existingRoom);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while updating room with ID {dto.Id}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var room = await _roomRepo.GetByIdAsync(id);
                if (room == null) return false;

                await _roomRepo.DeleteAsync(room);
                await _roomRepo.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting room with ID {id}", ex);
            }
        }
    }
}
