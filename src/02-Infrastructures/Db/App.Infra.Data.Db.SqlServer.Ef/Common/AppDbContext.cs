using App.Domain.Core.Car.CarModel.Entities;
using App.Domain.Core.Car.OPrator.Entities;
using App.Domain.Core.Car.User.Entities;
using App.Infra.Data.Db.SqlServer.Ef.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Common
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OPratorConfiguration ());
            modelBuilder.ApplyConfiguration(new ModelConfiguration  ());
            modelBuilder.ApplyConfiguration(new UserConfiguration ());
            

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserCar> UserCars { get; set; }
       public DbSet<OperatorCar> OperatorCars { get; set; }
        public  DbSet<Model> Models { get; set; }
        public DbSet<LogTable> LogTables { get; set; }
    }
}
