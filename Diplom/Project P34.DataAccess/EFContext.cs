using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_P34.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_P34.DataAccess
{
    public class EFContext : IdentityDbContext<User>
    {
        public EFContext(DbContextOptions<EFContext> options): base(options) { }

        public DbSet<UserMoreInfo> userMoreInfos { get; set; }

        public DbSet<Flat> flats { get; set; }
        public DbSet<FlatSquareInfo> FlatSquareInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(u => u.UserMoreInfo)
                .WithOne(t => t.User)
                .HasForeignKey<UserMoreInfo>(ui => ui.Id);

            builder.Entity<Flat>()
            .HasOne<FlatSquareInfo>(s => s.FlatSquareInfo)
            .WithMany(g => g.Flats)
            .HasForeignKey(s => s.SquareId);

            base.OnModelCreating(builder);
        }


    }
}
