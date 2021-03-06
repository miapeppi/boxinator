using AutoMapper;
using boxinator.Models;
using boxinator.Models.Domain;
using boxinator.Models.DTO.User;
using boxinator.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace boxinator.Controllers
{
    [ApiController]
    [Route("login")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly IAccountService _service;
        private readonly IMapper _mapper;

        public LoginController(IAccountService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Tries to login with email that's found in token. If email was not found in database, creates new user.
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns>Returns fetched user, created user or 400</returns>
        /// GET: /login/verify
        [ProducesResponseType(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]
        [HttpGet("/login/verify")]
        public async Task<ActionResult<UserReadDTO>> Verify()
        {
            // Fetch user's email from token
            var userEmail = Request.ExtractEmailFromToken();
            var resultUser = await _service.GetUser(userEmail);

            // If email was found in the database, returns user
            if(resultUser != null)
            {
                return _mapper.Map<UserReadDTO>(resultUser);
            } 
            // If the email wasn't found in the database, creates a new user and returns it.
            else if(resultUser is null)
            {
                User newUser = _mapper.Map<User>(new User()
                {
                    Email = userEmail,
                    AccountType = "GUEST",
                    CountryId = 1
                });
                
                User createdUser =  await _service.Add(newUser);
                return _mapper.Map<UserReadDTO>(createdUser);
            }
            return BadRequest();
        }
    }
}
