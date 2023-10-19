using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitYFramework.Context
{
    public class CarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString:
                "server=(localdb)\\MSSQLLocalDB;initial catalog=Avto;integrated security=true");

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Car> Cars { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> userOperationClaims { get; set; }

        public DbSet<Model> Models { get; set; }


    }
}
