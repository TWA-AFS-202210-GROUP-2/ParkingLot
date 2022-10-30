using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingBoyTest
    {
        [Fact]
        public void Should_return_a_ticket_when_parking_given_a_car()
        {
            var parkinglot = new Parkinglot("Parkinglot1");
            var parkingboy = new ParkingBoy("Jacky", parkinglot);
            var car = new Car("JJAA8888");

            var ticket = parkingboy.ParkingCar(car);

            Assert.IsType<ParkingTIcket>(ticket);
        }
    }
}
