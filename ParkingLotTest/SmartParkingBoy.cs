﻿using System;

namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_Park_Return_ParkingTicket_When_Park_To_Available_ParkingLot()
        {
            // given
            var car = new Car("JAA8888");
            var parkingLot1 = new Parkinglot("ParkingLotOne");
            var parkingLot2 = new Parkinglot("ParkingLotOne");
            var parkingBoy = new SmartParkingBoy("Jack", parkingLot1, parkingLot2);

            // when
            var parkingTicket = parkingBoy.Park(car);

            // then
            Assert.IsType<ParkingTicket>(parkingTicket);
        }

        [Fact]
        public void Should_Park_Return_Null_When_Park_Null_Car()
        {
            // given
            Car car = null;
            var parkingLot1 = new Parkinglot("ParkingLotOne");
            var parkingLot2 = new Parkinglot("ParkingLotOne");
            var parkingBoy = new SmartParkingBoy("Jack", parkingLot1, parkingLot2);

            // when
            var parkingTicket = parkingBoy.Park(car);

            // then
            Assert.Null(parkingTicket);
        }

        [Fact]
        public void Should_Fetch_Return_Car_With_Valid_ParkingTicket()
        {
            // given
            // given
            var parkedCar = new Car("JAA8888");
            var parkingLot1 = new Parkinglot("ParkingLotOne");
            var parkingLot2 = new Parkinglot("ParkingLotOne");
            var parkingBoy = new SmartParkingBoy("Jack", parkingLot1, parkingLot2);
            var parkingTicket = parkingBoy.Park(parkedCar);

            // when
            var fetchedCar = parkingBoy.Fetch(parkingTicket);

            // then
            Assert.IsType<Car>(fetchedCar);
            Assert.Equal(fetchedCar, parkedCar);
        }
    }
}