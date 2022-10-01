using Microsoft.EntityFrameworkCore;
using System;

namespace felipehilst_d7_avaliacao.Data
{
    public class LoginAppContext : DbContext
    {
        public LoginAppContext(DbContextOptions<LoginAppContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<User>().HasData(BaseData());
            base.OnModelCreating(mb);
        }

        private static User[] BaseData()
        {
            return new User[]
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "admin@email.com",
                    Password = "admin123"
                }
            };
        }
    }
}
