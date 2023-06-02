namespace TicketBookingCore.business
{
    public class TicketBookingRequestProcessor
    {
        private readonly ITicketBookingRepository _ticketBookingRepository;
        public TicketBookingRequestProcessor(ITicketBookingRepository ticketBookingRepository)
        {
            _ticketBookingRepository = ticketBookingRepository;
        }

        public TicketBookingResponse Book(TicketBookingRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var _tbooking = new TicketBooking
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            _ticketBookingRepository.Save(_tbooking);

            return new TicketBookingResponse
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };
        }
    }
}