using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using TaskTracker.API.Data;
using TaskTracker.API.Dtos;
using TaskTracker.API.Helpers;
using TaskTracker.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMainRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IMainRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        { 
            var user = await _repo.GetUser(id);

            var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(userToReturn);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> GetUsers()
        { 
            var users = await _repo.GetUsers();
            List<UserForDetailedDto> usersToReturn = new List<UserForDetailedDto>();
            foreach (User value in users) {
                usersToReturn.Add(_mapper.Map<UserForDetailedDto>(value));
            }
            return Ok(usersToReturn);
        }
    }
}