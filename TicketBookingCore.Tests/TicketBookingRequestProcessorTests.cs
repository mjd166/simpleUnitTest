using FluentAssertions;
using NSubstitute;
using TicketBookingCore.business;
namespace TicketBookingCore.Tests
{
    public class TicketBookingRequestProcessorTests
    {
        private readonly ITicketBookingRepository _repository;
        private readonly TicketBookingRequestProcessor _processor;
        private readonly TicketBookingRequest _request;


        public TicketBookingRequestProcessorTests()
        {
            _repository = Substitute.For<ITicketBookingRepository>();

            _processor = new TicketBookingRequestProcessor(_repository);
            _request = new TicketBookingRequest
            {
                FirstName = "Majid",
                LastName = "Ghafari",
                Email = "mghafari41@yahoo.com"
            };
        }

        [Fact]
        public void Should_Return_TicketBooking_Result_With_RequestValues()
        {
            //Arrange
            
           

            //Act
            TicketBookingResponse response = _processor.Book(_request);


            //Assert

            Assert.NotNull(response);
            Assert.Equal(_request.FirstName, response.FirstName);
            Assert.Equal(_request.LastName, response.LastName);
            Assert.Equal(_request.Email, response.Email);


        }


        [Fact]
        public void Should_Throw_Exception_When_Request_Is_Null()
        {
            //Arrange
            

            //Act
            var exception = Assert
                .Throws<ArgumentNullException>(() => _processor.Book(null));

            //Assert
            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void Should_Save_To_Database()
        {
            //Arrange
            

            ///Act
           
            TicketBookingResponse response = _processor.Book(_request);

            //Assert
            _repository.Received(1).Save(Arg.Any<TicketBooking>());
            _repository.ReceivedWithAnyArgs().Save(default);
            response.FirstName.Should().Be(_request.FirstName);
            response.LastName.Should().Be(_request.LastName);
         

        }
    }
}