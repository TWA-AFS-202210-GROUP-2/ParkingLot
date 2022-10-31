// Include namespace system
using System;

namespace ParkingLot
{
    public class Car
    {
        private string cardId;
        public Car(string cardId, string v)
        {
            this.cardId = cardId;
        }

        public string GetCardId()
        {
            return cardId;
        }
    }
}