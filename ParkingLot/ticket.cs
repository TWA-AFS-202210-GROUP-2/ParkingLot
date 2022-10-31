namespace ParkingLot
{
    public class Ticket
    {
        private string number;
        private Ticket(string number)
        {
            this.number = number;
        }

        public Ticket GenerateTicket(Car car)
        {
            return new Ticket(car.GetCardId());
        }

        public bool Equals(object o)
        {
            if (this == o)
            {
                return true;
            }

            if (o == null || this.GetType() != o.GetType())
            {
                return false;
            }

            var ticket = (Ticket)o;
            return this.number.Equals(ticket.number);
        }
    }
}