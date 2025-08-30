using HotelBooking.DAL.Data;
using HotelBooking.DAL.Interfaces;
using HotelBooking.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingDAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IRoomRepository Rooms { get; }
        public ICustomerRepository Customers { get; }
        public IReservationRepository Reservations { get; }
        public IPaymentRepository Payments { get; }

        public UnitOfWork(AppDbContext context,
                          IRoomRepository roomRepo,
                          ICustomerRepository customerRepo,
                          IReservationRepository reservationRepo,
                          IPaymentRepository paymentRepo)
        {
            _context = context;
            Rooms = roomRepo;
            Customers = customerRepo;
            Reservations = reservationRepo;
            Payments = paymentRepo;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
