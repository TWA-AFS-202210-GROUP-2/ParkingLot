using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingBoyTest
    {
        [Fact]
        public void Should_return_parking_ticket_when_parking_given_customer_car()
        {
            //given
            ParkingLots parkingLot = new ParkingLots("ParkingLot1");
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            Customer customer = new Customer("jack", "key");
            Car car = new Car(customer, "car1");
            //when
            var ticket = parkingBoy.ParkingCar(car);
            //then
            Assert.Equal("ParkingLot1: car1", ticket.Id);
        }

        [Fact]
        public void Should_return_car_when_customer_fetch_car_given_parking_ticket()
        {
            //given
            ParkingLots parkingLot = new ParkingLots("ParkingLot1");
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            Customer customer = new Customer("jack", "key");
            Car car = new Car(customer, "car1", parkingLot.ParkingLotName);
            //when
            var ticket = parkingBoy.ParkingCar(car);
            var fetchedCar = parkingBoy.FetchCar(ticket);
            //then
            Assert.Equal("car1", fetchedCar.CarId);
        }

        [Fact]
        public void Should_return_no_car_when_customer_fetch_car_given_wrong_parking_ticket()
        {
            //given
            ParkingLots parkingLot = new ParkingLots("ParkingLot1");
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            //when
            Action action = () => parkingBoy.FetchCar(null);
            //then
            Assert.Throws<ArgumentNullException>(action);
        }
    }
}
