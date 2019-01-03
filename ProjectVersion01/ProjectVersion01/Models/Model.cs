using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFGetStarted.AspNetCore.NewDb.Models
{


    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>()
                .HasKey(pr => new { pr.BicycleId, pr.PersonId });
            modelBuilder.Entity<Purchase>()
                .HasOne(pr => pr.Person)
                .WithMany(p => p.Purchases)
                .HasForeignKey(pr => pr.PersonId);
            modelBuilder.Entity<Purchase>()
                .HasOne(pr => pr.Bicycle)
                .WithMany(b => b.Purchases)
                .HasForeignKey(pr => pr.BicycleId);
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Bicycle> Bicycles { get; set; }
        public DbSet<Purchase> Purchases { get; set; }




    }
   

    public class Purchase
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int BicycleId { get; set; }
        public Bicycle Bicycle { get; set; }

    }

    public class Bicycle
    {
        [Key]
        public int BicycleId { get; set; }
        [Required(ErrorMessage ="Please enter name/type of bicycle.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public double Price { get; set; }
        public ICollection<Purchase> Purchases { get; set; }


    }

    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pasword { get; set;}
        public string Role { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public ICollection<Purchase> Purchases { get; set; }

    }



   

}