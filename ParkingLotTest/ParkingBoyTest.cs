namespace ParkingLotTest
{
    using ParkingLot;
    using System;
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
    }
}
