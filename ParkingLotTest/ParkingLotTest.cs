namespace ParkingLotTest
{
    using ParkingLot;
    using System.Collections.Generic;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_null_when_parking_lot_has_not_position_given_car()
        {
            //given
            ParkingLot_ parkingLot_ = new ParkingLot_("parkingLot one", 1);
            List<ParkingLot_> parkingLots = new List<ParkingLot_>();
            parkingLots.Add(parkingLot_);
            ParkingBoy parkingBoy = new ParkingBoy("Jim", parkingLots);
            Car car = new Car("J123456");
            Car car_2 = new Car("J654321");
            parkingBoy.ParkCar(car);

            //when
            var response = parkingBoy.ParkCar(car_2);

            //then
            Assert.Null(response);
        }
    }
}
