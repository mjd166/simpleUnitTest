namespace TicketBookingCore.business
{
    public class TicketBookingRepository : ITicketBookingRepository
    {
        private readonly TicketContext _context;

        public TicketBookingRepository(TicketContext context)
        {
            _context = context;
        }

        public void Save(TicketBooking ticket)
        {
            _context.Tickets.Add(new Ticket { Email=ticket.Email,FirstName=ticket.FirstName,LastName =ticket.LastName });
            _context.SaveChanges();
      
        }
    }
}