namespace ParkingLotTest
{
    using ParkingLot;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_return_ParkingTicket_when_parkingBoy_park_car_given_car()
        {
            //given
            Car car = new Car("J123456");
            ParkingLot_ parkingLot_ = new ParkingLot_("parkingLot 1");
            ParkingBoy parkingBoy = new ParkingBoy("Jim", parkingLot_);

            //when
            var ticket = parkingBoy.ParkCar(car);

            //then
            Assert.IsType<ParkingTicket>(ticket);
        }

        [Fact]
        public void Should_return_Car_when_parkingBoy_fetch_car_given_parking_ticket()
        {
            //given
            Car car = new Car("J123456");
            ParkingLot_ parkingLot_ = new ParkingLot_("parkingLot 1");
            ParkingBoy parkingBoy = new ParkingBoy("Jim", parkingLot_);
            var ticket = parkingBoy.ParkCar(car);

            //when
            var returnCar = parkingBoy.FetchCar(ticket);

            //then
            Assert.Equal(car, returnCar);
        }

        [Fact]
        public void Should_return_list_ticket_when_parkingBoy_park_list_car_given_cars()
        {
            //given
            List<Car> cars = new List<Car>();
            Car carOne = new Car("J123456");
            Car carTow = new Car("J654321");
            cars.Add(carOne);
            cars.Add(carTow);
            ParkingLot_ parkingLot_ = new ParkingLot_("parkingLot 1");
            ParkingBoy parkingBoy = new ParkingBoy("Jim", parkingLot_);
            //when
            var tickets = parkingBoy.ParkCars(cars);
            //then
            Assert.IsType<List<ParkingTicket>>(tickets);
        }

        [Fact]
        public void Should_return_list_car_when_parkingBoy_fetch_list_car_given_list_ticket()
        {
            //given
            List<Car> cars = new List<Car>();
            Car carOne = new Car("J123456");
            Car carTow = new Car("J654321");
            cars.Add(carOne);
            cars.Add(carTow);
            ParkingLot_ parkingLot_ = new ParkingLot_("parkingLot 1");
            ParkingBoy parkingBoy = new ParkingBoy("Jim", parkingLot_);
            var tickets = parkingBoy.ParkCars(cars);
            //when
            var getCars = parkingBoy.FetchCars(tickets);
            //then
            Assert.Equal(cars, getCars);
        }

        [Fact]
        public void Should_return_null_when_parkingBoy_fetch_car_given_wrong_ticket()
        {
            //given
            Car car = new Car("J123456");
            ParkingLot_ parkingLot_ = new ParkingLot_("parkingLot 1");
            ParkingBoy parkingBoy = new ParkingBoy("Jim", parkingLot_);
            var ticket = new ParkingTicket("J654321", parkingLot_);

            //when
            var returnCar = parkingBoy.FetchCar(ticket);

            //then
            Assert.Null(returnCar);
        }

        [Fact]
        public void Should_return_null_when_parkingBoy_fetch_car_given_null_ticket()
        {
            //given
            Car car = new Car("J123456");
            ParkingLot_ parkingLot_ = new ParkingLot_("parkingLot 1");
            ParkingBoy parkingBoy = new ParkingBoy("Jim", parkingLot_);

            //when
            var returnCar = parkingBoy.FetchCar(null);

            //then
            Assert.Null(returnCar);
        }

        [Fact]
        public void Should_return_null_when_parkingBoy_fetch_car_given_used_ticket()
        {
            //given
            Car car = new Car("J123456");
            ParkingLot_ parkingLot_ = new ParkingLot_("parkingLot 1");
            ParkingBoy parkingBoy = new ParkingBoy("Jim", parkingLot_);
            ParkingTicket ticket = parkingBoy.ParkCar(car);
            var returnCar = parkingBoy.FetchCar(ticket);

            //when
            var returnCar2 = parkingBoy.FetchCar(ticket);

            //then
            Assert.Null(returnCar2);
        }
    }
}
