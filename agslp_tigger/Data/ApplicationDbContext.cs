using agslp_tigger.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace agslp_tigger.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Wallet> wallet { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           builder.Entity<Wallet>().ToTable("walleritems").HasNoKey();
        }

    }


}
