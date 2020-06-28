using dev.eduardroid.services.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dev.eduardroid.services.Data
{
    public class ServiceContext : DbContext 
    {
        public DbSet<User> Users { get; set; }
        // public DbSet<NavigationRight> NavigationRights { get; set; }


        public ServiceContext(DbContextOptions<ServiceContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasData(
                    new User() { 
                        Id=1,
                        Nickname="eduardroid",
                        Email="edelcastillo@eduardroid.tech",
                        Password="123456"
                    }
                );
        }
    }
}
