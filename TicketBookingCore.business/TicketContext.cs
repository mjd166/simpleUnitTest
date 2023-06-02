using Microsoft.EntityFrameworkCore;

namespace TicketBookingCore.business
{
    public class TicketContext:DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options):base(options)
        {

        }


        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}