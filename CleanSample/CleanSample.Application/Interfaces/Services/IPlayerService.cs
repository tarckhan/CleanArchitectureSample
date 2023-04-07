using CleanSample.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanSample.Application.Interfaces.Services
{
    public interface IPlayerService
    {
        Task<List<PlayerDto>> GetAllPlayers();
        Task<bool> DeletePlayer(Guid Id);
        Task<bool> UpdatePlayer(PlayerDto player);
        Task<bool> AddPlayer(AddPlayerDto player);
    }
}
