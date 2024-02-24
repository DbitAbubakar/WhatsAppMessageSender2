using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WhatsAppMessageSender
{
    public class AppDbcontext : DbContext
    {
        public DbSet<Compagain> Compagains { get; set; }
        public DbSet<CompagainDetail> CompagainDetail { get; set; }
        //public object CompagainForm { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the connection string here
            //optionsBuilder.UseSqlServer("Server=DESKTOP-077B3EK\\SQLEXPRESS;Database=CompaigainData;Trusted_Connection=True;TrustServerCertificate=True;");
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=CompaigainData;User Id=postgres;Password=admin;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompagainDetail>()
                .HasOne(c => c.Compagain)
                .WithMany()
                .HasForeignKey(c => c.C_Id)
                .IsRequired();

            // Add other configurations as needed
        }
    }
}
