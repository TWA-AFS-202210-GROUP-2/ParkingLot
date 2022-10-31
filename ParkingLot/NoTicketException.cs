using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class NoTicketExcption : Exception
    {
        public NoTicketExcption(string msg) : base(msg)
        {

        }
    }
}
