using CleanSample.Application.ApiResult;
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
        public async Task<ApiResult<List<PlayerDto>>> GetAll()
        {
            var result = await _playerService.GetAllPlayers();
            return ApiResult<List<PlayerDto>>.OK(result);
        }

        [HttpPost]
        public async Task<ApiResult<bool>> Add([FromBody] AddPlayerDto playerDto)
        {
            var result = await _playerService.AddPlayer(playerDto);
            return ApiResult<bool>.OK(result);
        }
        [HttpPut]
        public async Task<ApiResult<bool>> UpdatePlayer([FromBody] PlayerDto playerDto)
        {
            var result = await _playerService.UpdatePlayer(playerDto);
            return ApiResult<bool>.OK(result);
        }
        [HttpDelete]
        public async Task<ApiResult<bool>> DeletePlayer([FromBody] Guid id)
        {
            var result = await _playerService.DeletePlayer(id);
            return ApiResult<bool>.OK(result);
        }
    }
}
