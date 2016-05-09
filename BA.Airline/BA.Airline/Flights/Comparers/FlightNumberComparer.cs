using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.Airline.Flights.Comparers
{
    public  class FlightNumberComparer : IComparer
    {
        

        int IComparer.Compare(object x, object y) {
           IFlight f1 = x as IFlight;
           IFlight f2 = y as IFlight;
            if (f1 != null && f2 != null)
                return f1.FlightNumber.CompareTo(f2.FlightNumber);
            else return 0;
        }

    }
}
