using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public class PracticeDbContext : DbContext
    {
        private IConfiguration _configuration;
        public DbSet<Sponsor> Sponsor { get; set; }
<<<<<<< HEAD
        public DbSet<Campaign> Campaign { get; set; }
=======
        public DbSet<Campaign> Campaing { get; set; }
>>>>>>> DouglasMain

        public PracticeDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetSection("Database").GetSection("ConnectionString").Value;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
