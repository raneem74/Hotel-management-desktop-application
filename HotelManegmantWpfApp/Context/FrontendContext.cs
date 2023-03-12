using HotelManegmantWpfApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManegmantWpfApp.Context
{
    internal class FrontendContext : DbContext
    {
        public DbSet<Frontend> Frontends { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;initial Catalog=Hotel_login;Integrated Security=True;Encrypt=false");
        }
    }
}
