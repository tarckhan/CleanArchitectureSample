using CleanSample.Application.CustomExceptions;
using CleanSample.Application.Interfaces;
using CleanSample.Application.Interfaces.Services;
using CleanSample.Application.Models.DTOs;
using CleanSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanSample.Infrastructure.Implementations.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IApplicationDbContext _dbContext;

        public PlayerService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddPlayer(AddPlayerDto player)
        {
            var team = await _dbContext.Teams.FirstOrDefaultAsync(x => x.Id == player.TeamId);

            if (team is null)
            {
                throw new ObjectNotFoundException("Invalid TeamId!");
            }

            var playerToAdd = new Player()
            {
                Id = Guid.NewGuid(),
                Firstname = player.Firstname,
                Lastname = player.Lastname,
                AdditionalInfo = player.AdditionalInfo,
                BirthDate = player.BirthDate,
                JerseyNumber = player.JerseyNumber,
                TeamId = player.TeamId
            };

            _dbContext.Players.Add(playerToAdd);
            return (await _dbContext.SaveChangesAsync()) > 0;
        }

        public async Task<bool> DeletePlayer(Guid Id)
        {
            if (string.IsNullOrEmpty(Id.ToString()))
            {
                throw new InvalidInputException("Invalid Guid");
            }

            var player = await _dbContext.Players.FirstOrDefaultAsync(player => player.Id == Id);

            if (player is null)
            {
                throw new ObjectNotFoundException($"Player with Id: {Id} not found!");
            }

            _dbContext.Players.Remove(player);

            return (await _dbContext.SaveChangesAsync()) > 0;
        }

        public async Task<List<PlayerDto>> GetAllPlayers()
        {
            return (await _dbContext.Players.ToListAsync()).Select(player => new PlayerDto
            {
                Id = player.Id,
                Firstname = player.Firstname,
                Lastname = player.Lastname,
                AdditionalInfo = player.AdditionalInfo,
                BirthDate = player.BirthDate,
                JerseyNumber = player.JerseyNumber,
                TeamId = player.TeamId
            }).ToList();
        }

        public async Task<bool> UpdatePlayer(PlayerDto playerToUpdate)
        {
            if (playerToUpdate is null || playerToUpdate.Id == Guid.Empty)
            {
                throw new InvalidInputException("Invalid Guid");
            }

            var player = await _dbContext.Players.FirstOrDefaultAsync(player => player.Id == playerToUpdate.Id);

            if (player is null)
            {
                throw new ObjectNotFoundException($"Player with Id: {playerToUpdate.Id} not found!");
            }

            var team = await _dbContext.Teams.FirstOrDefaultAsync(team => team.Id == playerToUpdate.TeamId);

            if (team is null)
            {
                throw new ObjectNotFoundException($"Team with Id: {playerToUpdate.TeamId} not found!");
            }

            player.Id = playerToUpdate.Id;
            player.AdditionalInfo = playerToUpdate.AdditionalInfo;
            player.BirthDate = playerToUpdate.BirthDate;
            player.Firstname = playerToUpdate.Firstname;
            player.Lastname = playerToUpdate.Lastname;
            player.JerseyNumber = playerToUpdate.JerseyNumber;
            player.TeamId = playerToUpdate.TeamId;

            _dbContext.Players.Update(player);

            return (await _dbContext.SaveChangesAsync()) > 0;
        }
    }
}