using CleanSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanSample.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Player> Players { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<Division> Divisions { get; set; }
        Task<int> SaveChangesAsync();
    }
}
