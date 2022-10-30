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

            var ticket = parkingboy.ParkCar(car);

            Assert.IsType<ParkingTicket>(ticket);
        }

        [Fact]
        public void Should_return_a_car_when_get_car_given_a_ticket()
        {
            var parkinglot = new Parkinglot("Parkinglot1");
            var parkingboy = new ParkingBoy("Jacky", parkinglot);
            var car = new Car("JJAA8888");

            var ticket = parkingboy.ParkCar(car);
            var carGet = parkingboy.GetCar(ticket);
            Assert.IsType<Car>(carGet);
        }
    }
}
