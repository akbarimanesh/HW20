using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Domain.Core.Car.OPrator.Entities;


public class OPratorConfiguration : IEntityTypeConfiguration<OperatorCar>
{
   
    public void Configure(EntityTypeBuilder<OperatorCar> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("OperatorCars");
        builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.UserName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Password).HasMaxLength(50).IsRequired();
       

        builder.HasData(new List<OperatorCar>()
            {
                new OperatorCar(){Id = 1 , FirstName = "لیلا" ,LastName="اکبری منش",UserName="leila" , Password="123"}
               
            });
    }
}