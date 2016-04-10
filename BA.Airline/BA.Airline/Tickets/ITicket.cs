using BA.Airline.Flights;
using BA.Airline.Passengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.Airline.Tickets
{
    public interface ITicket
    {
        IPassenger Passenger { get; set; }
        decimal Price { get; set; }
        SeatClass ClassOfSeat { get; set; }
        void PrintTicket();
        void BuyTicket(IPassenger passenger);
        IPassenger ShowOwner();
        void RefuseFromTicket();
        
    }
}
