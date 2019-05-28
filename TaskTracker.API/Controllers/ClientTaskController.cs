using System;
using System.Collections.Generic;
using System.Net.Http;
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
    public class ClientTaskController : ControllerBase
    {
        private readonly IMainRepository _repo;
        private readonly IMapper _mapper;
        public ClientTaskController(IMainRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet(Name = "GetAllClientTasks")]
        public async Task<IActionResult> GetAllClientTasks()
        {
            var clientTasks = await _repo.GetClientTasks();

            return Ok(clientTasks);
        }
        
        [HttpGet("{userId}", Name = "GetClientTaskForUser")]
        public async Task<IActionResult> GetClientTaskForUser(int userId)
        {
            var userFromRepo = await _repo.GetUser(userId);
            List<ClientTaskForDetailedDto> clientTasksToReturn = new List<ClientTaskForDetailedDto>();
            foreach (var value in userFromRepo.ClientTasks) {
                clientTasksToReturn.Add(_mapper.Map<ClientTaskForDetailedDto>(value));
            }
            
            return Ok(clientTasksToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddClientTask([FromBody] ClientTaskForAddDto clientTaskForAddDto)
        {
            var clientTaskToAdd = _mapper.Map<ClientTask>(clientTaskForAddDto);
            var userFromRepo = await _repo.GetUser(clientTaskForAddDto.ClientId);
            userFromRepo.ClientTasks.Add(clientTaskToAdd);

            if (await _repo.SaveAll())
            {
                return Ok("Task added successfully");
            }

            return BadRequest("Could not add the task");
        }

        [HttpDelete("{id}")]
        public async  Task<IActionResult> Delete(int id)
        {
            var clientTasks = await _repo.GetClientTasks();
            ClientTask clientTaskToDelete = new ClientTask();
            foreach (ClientTask value in clientTasks) {
                if (value.Id == id) {
                    clientTaskToDelete = value;
                    _repo.Delete<ClientTask>(clientTaskToDelete);                    
                }
            }
            if (clientTaskToDelete.Id == null) {
                return BadRequest("Error in deleting the task. Ensure the ID exists");
            }
            if (await _repo.SaveAll()) {
                return Ok("Task deleted successfully.");
            }
            else {
                return BadRequest("Unexpected error during deletion.");
            }
            
        }
    }

}