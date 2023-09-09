using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Prototype1.Models;

namespace Prototype1.Data
{
    public class ApplicationDbConetext: IdentityDbContext
    {
        public ApplicationDbConetext(DbContextOptions<ApplicationDbConetext>options): base(options)
        {
            
        }

        DbSet<ShowClass> Show { get; set; }
        public DbSet<ShowDateClass> ShowDate { get; set; }
        public DbSet<ShowTIcketsClass> showTickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
