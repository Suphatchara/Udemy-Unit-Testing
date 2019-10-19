using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;


namespace TestNinjaUnitTest.Mocking
{
    [TestFixture]
    public class BookingHelper_OverlappingBookingsExistTests
    {
        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            var mock = new Mock<IBookingRepository>();
            mock.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>
            {
                new Booking
                {

                }
            }.AsQueryable());
         

        }
    }
}

