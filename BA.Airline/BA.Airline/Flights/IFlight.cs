using BA.Airline.Passengers;
using BA.Airline.Tickets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.Airline.Flights
{
    public interface IFlight : IComparable
    {
        int FlightNumber { get; set; }
        ITicket[] TicketsOfFlight { get; set; }
        int NumberOfBusinessSeats { get; set; }
        int NumberOfEconomySeats { get; set; }
        decimal PriceForEconomy { get; set; }
        decimal PriceForBusiness { get; set; }
        int FreeSeats { get; }

        IFlight SearchByNumber(int numberOfFlight);
        IFlight DeletFlight(int numberOfFlight);
        void EditDirectionForFlight(int DirectionForFlight);
        void EditFlightCity(string city);
        void EditFlightNumber(int flightNumber);
        void EditFlightStatus(int status);
        void EditFlightNumberOfBusinessSeats(int numberOfSeats);
        void EditFlightNumberOfEconomySeats(int numberOfSeats);
        void EditFlightArrivalDeparting(DateTime dateTime);
        void EditFlightTerminal(int terminal);
        void EditFlightGate(int gate);
        void EditFlightPriceOfBussinesSeat(decimal price);
        void EditFlightPriceOfEconomySeat(decimal price);
        IFlight SearchByCost(decimal money);
        IPassenger[] SearchByNameLastname(string name);
        IPassenger SearchByPassport(string numberOfPassport);
        IPassenger SearchByNumberOfTicket(string numberOfTicket);
        IPassenger[] ShowPassengers();
        ITicket BuyTicket(IPassenger passenger, int numberOfSeat);
        ITicket RefuseFromTicket(string numberOfTicket, IPassenger passenger);
        string ToString();


    }
}
