using CleanSample.Application.Interfaces.Services;
using CleanSample.Application.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<List<PlayerDto>> GetAll() => await _playerService.GetAllPlayers();

        [HttpPost]
        public async Task<bool> Add([FromBody] AddPlayerDto playerDto) => await _playerService.AddPlayer(playerDto);
        
        [HttpPut]
        public async Task<bool> UpdatePlayer([FromBody] PlayerDto playerDto) => await _playerService.UpdatePlayer(playerDto);

        [HttpDelete]
        public async Task<bool> DeletePlayer([FromBody] Guid id) => await _playerService.DeletePlayer(id);
    }
}
