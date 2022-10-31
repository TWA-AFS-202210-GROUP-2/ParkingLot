namespace ParkingLotTest
{
    using ParkingLot;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_return_ParkingTicket_when_smartParkingBoy_park_car_given_car()
        {
            //given
            Car car = new Car("J123456");
            List<ParkingLot_> parkingLots = new List<ParkingLot_>();
            ParkingLot_ parkingLot_ = new ParkingLot_("parkingLot 1");
            parkingLots.Add(parkingLot_);
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy("Jim", parkingLots);

            //when
            var ticket = smartParkingBoy.ParkCar(car);

            //then
            Assert.IsType<ParkingTicket>(ticket);
        }

        [Fact]
        public void Should_return_Car_when_smartParkingBoy_fetch_car_given_parking_ticket()
        {
            //given
            Car car = new Car("J123456");
            List<ParkingLot_> parkingLots = new List<ParkingLot_>();
            ParkingLot_ parkingLot_ = new ParkingLot_("parkingLot 1");
            parkingLots.Add(parkingLot_);
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy("Jim", parkingLots);
            var ticket = smartParkingBoy.ParkCar(car);

            //when
            var returnCar = smartParkingBoy.FetchCar(ticket);

            //then
            Assert.Equal(car, returnCar);
        }

        [Fact]
        public void Should_return_list_ticket_when_smartParkingBoy_park_list_car_given_cars()
        {
            //given
            List<Car> cars = new List<Car>();
            Car carOne = new Car("J123456");
            Car carTow = new Car("J654321");
            cars.Add(carOne);
            cars.Add(carTow);
            List<ParkingLot_> parkingLots = new List<ParkingLot_>();
            ParkingLot_ parkingLot_ = new ParkingLot_("parkingLot 1");
            parkingLots.Add(parkingLot_);
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy("Jim", parkingLots);
            //when
            var tickets = smartParkingBoy.ParkCars(cars);
            //then
            Assert.IsType<List<ParkingTicket>>(tickets);
        }

        [Fact]
        public void Should_return_list_car_when_smartParkingBoy_fetch_list_car_given_list_ticket()
        {
            //given
            List<Car> cars = new List<Car>();
            Car carOne = new Car("J123456");
            Car carTow = new Car("J654321");
            cars.Add(carOne);
            cars.Add(carTow);
            List<ParkingLot_> parkingLots = new List<ParkingLot_>();
            ParkingLot_ parkingLot_ = new ParkingLot_("parkingLot 1");
            parkingLots.Add(parkingLot_);
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy("Jim", parkingLots);
            var tickets = smartParkingBoy.ParkCars(cars);
            //when
            var getCars = smartParkingBoy.FetchCars(tickets);
            //then
            Assert.Equal(cars, getCars);
        }

        [Fact]
        public void Should_return_null_when_smartParkingBoy_fetch_car_given_wrong_ticket()
        {
            //given
            Car car = new Car("J123456");
            List<ParkingLot_> parkingLots = new List<ParkingLot_>();
            ParkingLot_ parkingLot_ = new ParkingLot_("parkingLot 1");
            parkingLots.Add(parkingLot_);
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy("Jim", parkingLots);
            var ticket = new ParkingTicket("J654321", parkingLot_);

            //when
            var returnCar = smartParkingBoy.FetchCar(ticket);

            //then
            Assert.Null(returnCar);
        }

        [Fact]
        public void Should_return_null_when_smartParkingBoy_fetch_car_given_null_ticket()
        {
            //given
            Car car = new Car("J123456");
            List<ParkingLot_> parkingLots = new List<ParkingLot_>();
            ParkingLot_ parkingLot_ = new ParkingLot_("parkingLot 1");
            parkingLots.Add(parkingLot_);
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy("Jim", parkingLots);

            //when
            var returnCar = smartParkingBoy.FetchCar(null);

            //then
            Assert.Null(returnCar);
        }

        [Fact]
        public void Should_return_null_when_smartParkingBoy_fetch_car_given_used_ticket()
        {
            //given
            Car car = new Car("J123456");
            List<ParkingLot_> parkingLots = new List<ParkingLot_>();
            ParkingLot_ parkingLot_ = new ParkingLot_("parkingLot 1");
            parkingLots.Add(parkingLot_);
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy("Jim", parkingLots);
            ParkingTicket ticket = smartParkingBoy.ParkCar(car);
            var returnCar = smartParkingBoy.FetchCar(ticket);

            //when
            var returnCar2 = smartParkingBoy.FetchCar(ticket);

            //then
            Assert.Null(returnCar2);
        }

        /*[Fact]
        public void Should_console_response_message_when_parkingBoy_fetch_car_given_wrong_ticket()
        {
            //given
            Car car = new Car("J123456");
            ParkingLot_ parkingLot_ = new ParkingLot_("parkingLot 1");
            ParkingBoy smartParkingBoy = new ParkingBoy("Jim", parkingLot_);
            var ticket = new ParkingTicket("J654321", parkingLot_);

            //when
            smartParkingBoy.FetchCar(ticket);

            //then
            //how to test console message??
        }*/

        [Fact]
        public void Should_park_into_second_parking_log_when_second_parking_lot_has_more_position_given_car()
        {
            //given
            Car car = new Car("J123456");
            List<ParkingLot_> parkingLots = new List<ParkingLot_>();
            ParkingLot_ parkingLotOne = new ParkingLot_("parkingLot 1", 2);
            ParkingLot_ parkingLotTow = new ParkingLot_("parkingLot 2", 5);
            parkingLots.Add(parkingLotOne);
            parkingLots.Add(parkingLotTow);
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy("Jim", parkingLots);

            //when
            var ticket = smartParkingBoy.ParkCar(car);

            //then
            Assert.Equal("parkingLot 2", ticket.GetParkingLot().GetParkingLotName());
        }
    }
}
