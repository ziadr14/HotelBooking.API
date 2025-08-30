﻿using HotelBooking.BLL.DTOs;
using HotelBooking.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CarDealershipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthControllers : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthControllers(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto userDto)
        {
            var user = await _authService.RegisterAsync(userDto);

            if (user == null)
            {
                return BadRequest("Username Already Exists");
            }

            return Ok(user);
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody] LoginDto userDto)
        {
            var token = await _authService.LoginAsync(userDto);
            if (token == null)
            {
                return BadRequest("Invalid username or password");
            }

            return Ok(token);
        }


    }
}
