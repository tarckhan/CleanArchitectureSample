using CleanSample.Application.Interfaces;
using CleanSample.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CleanSample.Infrastructure.SeedDatabase
{
    public static class DbInitializer
    {
        public static void SeedDatabase(IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<IApplicationDbContext>();

                if (!dbContext.Divisions.Any() && !dbContext.Teams.Any() && !dbContext.Players.Any())
                {
                    var firstDivisonGuid = Guid.NewGuid();

                    Division firstDivision = new Division()
                    {
                        Id = firstDivisonGuid,
                        DivisionCode = "NW",
                        Name = "North West",
                    };

                    var firstTeamGuid = Guid.NewGuid();
                    
                    Team firsTeam = new Team()
                    {
                        Id = firstTeamGuid,
                        DivisionId = firstDivisonGuid,
                        Name = "Los Angeles Lakers",
                        AdditionalInfo = "The team of LA"
                    };

                    Player firstPlayer = new Player()
                    {
                        Id = Guid.NewGuid(),
                        BirthDate = new DateTime(1985, 1, 1),
                        Firstname = "LeBron",
                        Lastname = "James",
                        JerseyNumber = 23,
                        TeamId = firstTeamGuid,
                        AdditionalInfo = "The GOAT!"
                    };

                    dbContext.Divisions.Add(firstDivision);
                    dbContext.Teams.Add(firsTeam);
                    dbContext.Players.Add(firstPlayer);

                    var secondDivisonGuid = Guid.NewGuid();

                    Division secondDivision = new Division()
                    {
                        Id = secondDivisonGuid,
                        DivisionCode = "PA",
                        Name = "Pacific",
                    };

                    var secondTeamGuid = Guid.NewGuid();
                    Team secondTeam = new Team()
                    {
                        Id = secondTeamGuid,
                        DivisionId = secondDivisonGuid,
                        Name = "Golden State Warriors",
                        AdditionalInfo = "The Bay Area Team"
                    };

                    Player secondPlayer = new Player()
                    {
                        Id = Guid.NewGuid(),
                        BirthDate = new DateTime(1992, 1, 1),
                        Firstname = "Stephen",
                        Lastname = "Curry",
                        JerseyNumber = 30,
                        TeamId = secondTeamGuid,
                        AdditionalInfo = "Three Point King"
                    };

                    dbContext.Divisions.Add(secondDivision);
                    dbContext.Teams.Add(secondTeam);
                    dbContext.Players.Add(secondPlayer);

                    dbContext.SaveChangesAsync().GetAwaiter().GetResult();
                }
            }
        }
    }
}
