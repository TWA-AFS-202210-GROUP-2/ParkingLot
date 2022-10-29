using System;
using System.Drawing;
using Microsoft.VisualBasic;

namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_parking_ticket_when_customer_parking_given_parkingboy_a_car()
        {
            //given
            var car = new Car("car 1");
            var customer = new Customer("lucy");
            var parkingFloor = new ParkingFloor(30, name: "floor1");
            var parkingBoy = new ParkingBoy("Boy");
            parkingBoy.AddParkingFloor(parkingFloor);
            //when
            string mg = customer.ParkCar(car, parkingBoy);
            
            Car myCar = customer.RetriveCar(parkingBoy);
            string act = myCar.CarName;
            //then
            string exp = "car 1";
            Assert.Equal(exp, act);
        }
    }
}
