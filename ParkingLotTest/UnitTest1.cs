using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Moq;
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
            IEnumerable<Car> myCar = customer.RetriveCar(parkingBoy);
            string act = myCar.First().CarName;
            //then
            string exp = "car 1";
            Assert.Equal(exp, act);
        }

        [Fact]
        public void Should_return_parking_tickets_when_customer_parking_given_parkingboy_mutiple_cars()
        {
            //given
            List<Car> carList = new List<Car>();
            carList.Add(new Car("car1"));
            carList.Add(new Car("car2"));
            carList.Add(new Car("car3"));
            var customer = new Customer("lucy");
            var parkingFloor = new ParkingFloor(30, name: "floor1");
            var parkingBoy = new ParkingBoy("Boy");
            parkingBoy.AddParkingFloor(parkingFloor);
            //when
            string mg = customer.ParkCar(carList, parkingBoy);

            List<Car> myCar = customer.RetriveCar(parkingBoy);
            string act1 = myCar.First().CarName;
            var act2 = myCar[1].CarName;
            var act3 = myCar[2].CarName;
            //then
            string exp1 = "car1";
            string exp2 = "car2";
            string exp3 = "car3";
            Assert.Equal(exp1, act1);
            Assert.Equal(exp2, act2);
            Assert.Equal(exp3, act3);
        }

        [Fact]
        public void Should_return_no_car_when_customer_retrive_car_given_parkingboy_outdated_ticket()
        {
            //given
            var customer = new Customer("lucy");
            var parkingFloor = new ParkingFloor(30, name: "floor1");
            var parkingBoy = new ParkingBoy("Boy");
            
            parkingBoy.AddParkingFloor(parkingFloor);
            var fakeTicket = new Ticket(10000, "fake floor");
            customer.AddTicket(fakeTicket);
            //when
         
            WrongTicketExcption exception = Assert.Throws<WrongTicketExcption>(() => customer.RetriveCar(parkingBoy));
            //then
            Assert.Equal("no such ticket", exception.Message);
        }
        [Fact]
        public void Should_return_no_car_when_customer_retrive_car_given_parkingboy_used_ticket()
        {
            //given
            var customer = new Customer("lucy");
            var parkingFloor = new ParkingFloor(30, name: "floor1");
            var parkingBoy = new ParkingBoy("Boy");

            parkingBoy.AddParkingFloor(parkingFloor);
            customer.ParkCar(new Car("car 1"),parkingBoy);
            var cars = customer.RetriveCar(parkingBoy);
            var fakeTicket = new Ticket(1, "floor1");
            customer.AddTicket(fakeTicket);
            //when

            WrongTicketExcption exception = Assert.Throws<WrongTicketExcption>(() => customer.RetriveCar(parkingBoy));
            //then
            Assert.Equal("no such ticket", exception.Message);
        }
        [Fact]
        public void Should_return_no_space_when_customer_park_car_given_parkingboy_no_space()
        {
            //given
            var customer = new Customer("lucy");
            var parkingFloor = new ParkingFloor(2, name: "floor1");
            var parkingBoy = new ParkingBoy("Boy");
            List<Car> carList = new List<Car>();
            carList.Add(new Car("car1"));
            carList.Add(new Car("car2"));
            carList.Add(new Car("car3"));
            parkingBoy.AddParkingFloor(parkingFloor);

            //when
            
            NotEnoughCapacityException exception = Assert.Throws<NotEnoughCapacityException>(() => customer.ParkCar(carList, parkingBoy));
            //then
            Assert.Equal("not enough capacity", exception.Message);
        }
    }
}
