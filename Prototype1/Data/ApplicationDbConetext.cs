using Microsoft.EntityFrameworkCore;
using Prototype1.Models;

namespace Prototype1.Data
{
    public class ApplicationDbConetext: DbContext
    {
        public ApplicationDbConetext(DbContextOptions<ApplicationDbConetext>options): base(options)
        {
            
        }

        DbSet<ShowClass> Show { get; set; }
        public DbSet<ShowDateClass> ShowDate { get; set; }
        public DbSet<ShowTIcketsClass> showTickets { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<ShowClass>().HasData(
        //        new ShowClass
        //        {
        //            Id = 1,
        //            Name = "The Best Drama",
        //            StartDate = new DateTime(2023, 7, 16),
        //            EndDate= new DateTime(2023, 7, 23),
        //            Description= "This is the best Drama you could have ever ask for",
        //            imgurl=""
        //        });

           
        //}
    }
}
