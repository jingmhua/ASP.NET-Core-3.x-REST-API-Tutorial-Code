using Microsoft.EntityFrameworkCore;
using MyApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Data
{
    public class MyApiDBContext:DbContext
    {
        public MyApiDBContext(DbContextOptions<MyApiDBContext> options):base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().Property(x => x.Name)
                .IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Employee>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.ComapanyId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Company>().HasData(
                new Company { Id=Guid.NewGuid(), Name="company1", Introduction="c1" },
                new Company { Id = Guid.NewGuid(), Name = "company2", Introduction = "c2" }
                );
        }
    }
}
