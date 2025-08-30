"""# 🏨 Hotel Booking API

This is a multi-layer **ASP.NET Core Web API** project for managing a hotel booking system.  
It follows a clean architecture using **Repository Pattern**, **Unit of Work**, and **AutoMapper** to ensure separation of concerns and maintainability.  

The system supports managing:
- Hotels
- Rooms
- Customers
- Reservations

It also includes:
- Authentication & Authorization
- DTOs for clean data transfer
- EF Core for database operations
- AutoMapper for object mapping

---

## 🛠 Technologies Used

- **ASP.NET Core Web API (.NET 8)**  
- **Entity Framework Core** for ORM  
- **SQL Server** as the database  
- **AutoMapper** for object mapping  
- **Repository Pattern** & **Unit of Work**  
- **JWT Authentication** & **Role-based Authorization**  
- **Swagger / OpenAPI** for API documentation  

---

## 🔑 Key Features

1. **Authentication & Authorization**
   - JWT-based authentication
   - Role-based access control (Admin, Customer, Manager)
   - Secure password hashing  

2. **Hotels Management**
   - CRUD operations for hotels
   - Linked to rooms and reservations

3. **Rooms Management**
   - CRUD operations for rooms
   - Room availability check before booking

4. **Customers Management**
   - Manage customer info
   - Booking history retrieval

5. **Reservations**
   - Book rooms for customers
   - Prevent double booking with validation
   - Update or cancel reservations

6. **Repository & Unit of Work**
   - Clean separation between data access and business logic  
   - Centralized transaction handling  

7. **Error Handling**
   - Validation for dates (check-in < check-out)  
   - Business rules validation before deletion or updates  

---

## 📄 API Endpoints Overview

### Authentication
| Method | Endpoint              | Description            | Role Required |
|--------|----------------------|------------------------|---------------|
| POST   | `/api/auth/register` | Register new user       | Public        |
| POST   | `/api/auth/login`    | Login and get JWT token | Public        |

### Hotels
| Method | Endpoint           | Description          | Role Required |
|--------|-------------------|----------------------|---------------|
| GET    | `/api/hotels`     | Get all hotels       | Any           |
| GET    | `/api/hotels/{id}`| Get hotel by ID      | Any           |
| POST   | `/api/hotels`     | Add a new hotel      | Admin, Manager |
| PUT    | `/api/hotels/{id}`| Update hotel details | Admin, Manager |
| DELETE | `/api/hotels/{id}`| Delete a hotel       | Admin         |

### Rooms
| Method | Endpoint           | Description          | Role Required |
|--------|-------------------|----------------------|---------------|
| GET    | `/api/rooms`      | Get all rooms        | Any           |
| GET    | `/api/rooms/{id}` | Get room by ID       | Any           |
| POST   | `/api/rooms`      | Add a new room       | Admin, Manager |
| PUT    | `/api/rooms/{id}` | Update room details  | Admin, Manager |
| DELETE | `/api/rooms/{id}` | Delete a room        | Admin         |

### Customers
| Method | Endpoint              | Description           | Role Required |
|--------|----------------------|-----------------------|---------------|
| GET    | `/api/customers`     | Get all customers     | Admin, Manager |
| GET    | `/api/customers/{id}`| Get customer by ID    | Admin, Manager |
| POST   | `/api/customers`     | Add a new customer    | Admin, Manager |
| PUT    | `/api/customers/{id}`| Update customer info  | Admin, Manager |
| DELETE | `/api/customers/{id}`| Delete a customer     | Admin         |

### Reservations
| Method | Endpoint                  | Description              | Role Required |
|--------|---------------------------|--------------------------|---------------|
| GET    | `/api/reservations`       | Get all reservations     | Admin, Manager |
| GET    | `/api/reservations/{id}`  | Get reservation by ID    | Admin, Manager |
| POST   | `/api/reservations`       | Create a new reservation | Customer, Manager |
| PUT    | `/api/reservations/{id}`  | Update reservation       | Customer, Manager |
| DELETE | `/api/reservations/{id}`  | Cancel reservation       | Customer, Manager |

---

## ⚙️ How to Run

1. **Clone the repository**
   ```bash
   git clone https://github.com/ziadr14/HotelBooking.API.git

## Project Structure
```bash
HotelBookingAPI/
│── HotelBookingAPI/                 # API Layer
│   ├── Controllers/
│   │   └── HotelsController.cs
│   │   └── RoomsController.cs
│   │   └── CustomersController.cs
│   │   └── ReservationsController.cs
│   ├── DTOs/
│   │   └── HotelDto.cs
│   │   └── RoomDto.cs
│   │   └── CustomerDto.cs
│   │   └── ReservationDto.cs
│   ├── Program.cs
│
│── HotelBookingBLL/                 # Business Logic Layer
│   ├── Interfaces/
│   │   └── IHotelService.cs
│   │   └── IRoomService.cs
│   │   └── ICustomerService.cs
│   │   └── IReservationService.cs
│   ├── Services/
│   │   └── HotelService.cs
│   │   └── RoomService.cs
│   │   └── CustomerService.cs
│   │   └── ReservationService.cs
│   ├── DTOs/
│   ├── Mappings/
│   │   └── AutoMapperProfile.cs
│
│── HotelBookingDAL/                 # Data Access Layer
│   ├── Models/
│   │   └── Hotel.cs
│   │   └── Room.cs
│   │   └── Customer.cs
│   │   └── Reservation.cs
│   ├── Interfaces/
│   │   └── IBaseRepository.cs
│   │   └── IHotelRepository.cs
│   │   └── IRoomRepository.cs
│   │   └── ICustomerRepository.cs
│   │   └── IReservationRepository.cs
│   ├── Repositories/
│   │   └── BaseRepository.cs
│   │   └── HotelRepository.cs
│   │   └── RoomRepository.cs
│   │   └── CustomerRepository.cs
│   │   └── ReservationRepository.cs
│   │   └── UnitOfWork.cs
│   ├── Data/
│   │   └── AppDbContext.cs
│   └── Migrations/
│
└── HotelBookingAPI.sln
