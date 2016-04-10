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


        IFlight SearchByNumber(int numberOfFlight);
        IFlight DeletFlight(int numberOfFlight);
        void EditFlightArrivedDepartedStatus(int arrivedDepartedStatus);
        void EditFlightNumberOfBusinessSeats(int numberOfSeats);
        void EditFlightNumberOfEconomySeats(int numberOfSeats);
        IFlight SearchByCost(decimal money);
        IPassenger[] SearchByNameLastname(string name);
        IPassenger SearchByPassport(string numberOfPassport);
        IPassenger[] ShowPassengers();
        ITicket BuyTicket(IPassenger passenger, int numberOfSeat);
        ITicket RefuseFromTicket(int numberOfTicket);
        string ToString();


    }
}
