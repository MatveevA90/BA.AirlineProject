using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BA.Airline.Passengers;
using BA.Airline.Tickets;

namespace BA.Airline.Flights
{
    public enum Status
    {
        ChekIn = 1, GateClosed, Arrived, DepartedAt, Unknown, Canceled, ExpectedAt, Delayed, InFlight
    }
    public enum ArrivedDeparted { Arrived = 1, Departed }
    public sealed class Flight : IFlight
    {
        private DateTime _arrivalDeparted;
        private int _flightNumber;
        private int _terminal;
        private int _gate;
        private int _numberOfSeats;
        public ArrivedDeparted ArrivedDeparted { get; set; }
        public ITicket[] TicketsOfFlight { get; set; }
        public DateTime ArrivalDeparting
        {
            get { return _arrivalDeparted; }
            set
            {
                DateTime now = new DateTime();
                now = DateTime.Now;
                //if (value <= now)
                //    _arrivalDeparted = now.AddHours(3);
                //else
                //    _arrivalDeparted = value;
                _arrivalDeparted = (value <= now.AddMinutes(30)) ? now.AddHours(3) : value;
            }
        }
        public int FlightNumber
        {
            get { return _flightNumber; }
            set
            {
                Random rnd = new Random();
                _flightNumber = (value <= 0) ? rnd.Next(2, 999) : value;
            }
        }
        public Status FlightStatus { get; set; }
        public string City { get; set; }
        public decimal PriceForEconomy { get; set; }
        public decimal PriceForBusiness { get; set; }
        public int Terminal
        {
            get { return _terminal; }
            set
            {
                Random rnd = new Random();
                _terminal = (value <= 0) ? rnd.Next(1, 10) : value;
            }
        }
        public int Gate
        {
            get { return _gate; }
            set
            {
                Random rnd = new Random();
                _gate = (value <= 0) ? rnd.Next(1, 5) : value;
            }
        }
        public int NumberOfSeats
        {
            get { return _numberOfSeats; }
            set
            {
                Random rnd = new Random();
                _numberOfSeats = (value <= 0 && value >= 500) ? rnd.Next(3, 500) : value;
            }
        }

        public IFlight DeletFlight(int flightNumber) {
            if (this.FlightNumber == flightNumber)
                return null;
            else
                return this;
        }

        public void EditFlightArrivedDepartedStatus(int arrivedDepartedStatus) {

        }

        public void PrintAllFlights(IFlight[] flights) {
            foreach (var flight in flights)
            {
                Console.WriteLine(flight.ToString());
            }
        }

        public void SearchByCost(decimal money, IFlight[] flights) {
            for (int i = 0; i < flights.Length; i++)
            {
                for (int j = 0; j < flights[i].TicketsOfFlight.Length; j++)
                    if (flights[i].TicketsOfFlight[j].ClassOfSeat == (SeatClass)0)
                        if (flights[i].TicketsOfFlight[j].Price < money)
                        {
                            Console.WriteLine(flights[i].ToString());
                            break;
                        }
            }

        }

        public IFlight SearchByNumber(int numberOfFlight, IFlight[] flights) {
            for (int i = 0; i < flights.Length; i++)
            {
                if (flights[i].FlightNumber == numberOfFlight)
                    return flights[i];
            }
            return null;
        }

        public IPassenger[] ShowPassengers(IFlight[] flights) {
            IPassenger[] passengers = new IPassenger[20];
            int i = 0;
            foreach (var flight in flights)
            {
                foreach (var ticket in flight.TicketsOfFlight)
                {
                    if (ticket.Passenger != null)
                    {
                        passengers[i] = ticket.Passenger;
                        i++;
                    }
                }
            }
            return passengers;
        }

        public ITicket BuyTicket(IPassenger passenger) {
            throw new NotImplementedException();
        }



        public Flight() { }
        public Flight(string city, int numberOfFlight, int status, int numberOfSeats, DateTime arrivalDepartedTime,
            int terminal, int gate, decimal priceForBusiness, decimal priceForEconomy = 0) {
            City = city;
            FlightNumber = numberOfFlight;
            FlightStatus = (Status)status;
            NumberOfSeats = numberOfSeats;
            ArrivalDeparting = arrivalDepartedTime;
            Terminal = terminal;
            Gate = gate;
            PriceForEconomy = priceForEconomy;
            PriceForBusiness = priceForBusiness;

            if (NumberOfSeats < 3)
            {
                TicketsOfFlight = new ITicket[NumberOfSeats];
                for (int i = 0; i < TicketsOfFlight.Length; i++)
                {
                    TicketsOfFlight[i] = new Ticket(this, i + 1, (SeatClass)1, PriceForBusiness, i + 1);
                }
            } else
            {
                TicketsOfFlight = new ITicket[NumberOfSeats];
                for (int i = 0; i < TicketsOfFlight.Length / 3; i++)
                {
                    TicketsOfFlight[i] = new Ticket(this, i + 1, (SeatClass)1, PriceForBusiness, i + 1);
                }
                for (int i = TicketsOfFlight.Length / 3; i < TicketsOfFlight.Length; i++)
                {
                    TicketsOfFlight[i] = new Ticket(this, i + 1, (SeatClass)2, PriceForEconomy, i + 1);
                }

            }
        }
    }
}
