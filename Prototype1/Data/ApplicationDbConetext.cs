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
        DbSet<ShowDateClass> ShowDate { get; set; }
        DbSet<ShowTIcketsClass> showTickets { get; set; }
    }
}
