using HotelBooking.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRoomRepository Rooms { get; }
        ICustomerRepository Customers { get; }
        IReservationRepository Reservations { get; }
        IPaymentRepository Payments { get; }

        Task SaveAsync();
    }
}
