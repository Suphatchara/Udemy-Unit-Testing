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
            var repository = new Mock<IBookingRepository>();
            repository.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>
            {
                new Booking
                {
                    Id = 2,
                    ArrivalDate = ArriveOn(2017, 1, 15),
                    DepartureDate = DepartOn(2017, 1, 20),
                    Reference = "a"


                }
            }.AsQueryable());

            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = ArriveOn(2017, 1, 1),
                DepartureDate = DepartOn(2017, 1, 14),


            }, repository.Object);

            Assert.That(result, Is.Empty);

        }

        private DateTime ArriveOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime DepartOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }
    }
}

