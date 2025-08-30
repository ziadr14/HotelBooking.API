﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DAL.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName {  get; set; }

        public string Role { get; set; }
    }
}
