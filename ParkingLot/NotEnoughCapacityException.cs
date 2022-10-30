using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class NotEnoughCapacityException : Exception
    {
        public NotEnoughCapacityException(string msg) : base(msg)
        {

        }
    }
}
