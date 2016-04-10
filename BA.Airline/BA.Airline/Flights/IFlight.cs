using BA.Airline.Passengers;
using BA.Airline.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.Airline.Flights
{
    public interface IFlight
    {
        int FlightNumber { get; set; }
        ITicket[] TicketsOfFlight { get; set; }

        void PrintFlight();
        IFlight SearchByNumber(int numberOfFlight);
        IFlight DeletFlight(int numberOfFlight);
        void EditFlight(int numberOfFlight);
        void SearchByCost(decimal money);
        IPassenger[] SearchByNameLastname();
        IPassenger[] SearchByPassport();
        IPassenger[] ShowPassengers();
        ITicket BuyTicket(IPassenger passenger);
        ITicket RefuseFromTicket(IPassenger passenger);
        string ToString();


    }
}
