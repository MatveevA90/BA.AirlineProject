using BA.Airline.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.Airline.Passengers
{
    public interface IPassenger
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        string NumberOfPassport { get; set; }
        string ToString();
      
    }
}
