using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RZAWeb.Models;

namespace RZAWeb.Data
{
    public class RZAWebContext : DbContext
    {
        public RZAWebContext (DbContextOptions<RZAWebContext> options)
            : base(options)
        {
        }
        //these are all generated automatically and will allow me to interact with the database tables for each of them from the controller (read + write)
        public DbSet<BookZooTickets> BookZooTickets { get; set; }

        public DbSet<BookHotelRooms> BookHotelRooms { get; set; }
        public DbSet<Rewards> Rewards { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
