using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class WrongTicketExcption : Exception
    {
        public WrongTicketExcption(string msg) : base(msg)
        {

        }
    }
}
