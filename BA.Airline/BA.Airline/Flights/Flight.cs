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
        private int flightNumber;

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
        public int NumberOfBusinessSeats { get; set; }
        public int NumberOfEconomySeats { get; set; }
        public IFlight DeletFlight(int flightNumber) {
            if (this.FlightNumber == flightNumber)
                return null;
            else
                return this;
        }

        public void EditFlightArrivedDepartedStatus(int arrivedDepartedStatus) {
            ArrivedDeparted = (ArrivedDeparted)arrivedDepartedStatus;
        }
        public void EditFlightCity(string city) => City = city;
        public void EditFlightNumber(int flightNUmber) => FlightNumber = flightNumber;
        public void EditFlightStatus(int status) => FlightStatus = (Status)status;
        public void EditFlightNumberOfBusinessSeats(int numberOfSeats) {
            int i = 0;
            foreach (var passenger in TicketsOfFlight)
            {
                if (passenger != null)
                    if (passenger.ClassOfSeat == (SeatClass)1)
                        i++;
            }
            if (i <= numberOfSeats)
                NumberOfBusinessSeats = numberOfSeats;
        }
        public void EditFlightNumberOfEconomySeats(int numberOfSeats) {
            int i = 0;
            foreach (var passenger in TicketsOfFlight)
            {
                if (passenger != null)
                    if (passenger.ClassOfSeat == (SeatClass)2)
                        i++;
            }
            if (i <= numberOfSeats)
                NumberOfEconomySeats = numberOfSeats;
        }
        public void EditFlightArrivalDeparting(DateTime dateTime) => ArrivalDeparting = dateTime;
        public void EditFlightTerminal(int terminal) => Terminal = terminal;
        public void EditFlightGate(int gate) => Gate = gate;
        public void EditFlightPriceOfBussinesSeat(decimal price) {
            for (int i = 0; i < TicketsOfFlight.Length; i++)
            {
                if (TicketsOfFlight[i].Passenger == null)
                    if (TicketsOfFlight[i].ClassOfSeat == (SeatClass)1)
                        TicketsOfFlight[i].Price = price;
            }
        }
        public void EditFlightPriceOfEconomySeat(decimal price) {
            for (int i = 0; i < TicketsOfFlight.Length; i++)
            {
                if (TicketsOfFlight[i].Passenger == null)
                    if (TicketsOfFlight[i].ClassOfSeat == (SeatClass)2)
                        TicketsOfFlight[i].Price = price;
            }
        }

        public IFlight SearchByCost(decimal money) {
            for (int i = 0; i < TicketsOfFlight.Length; i++)
            {
                if (TicketsOfFlight[i].ClassOfSeat == (SeatClass)0)
                    if (TicketsOfFlight[i].Price < money)
                    {
                        return this;
                    }
            }
            return null;
        }

        public IFlight SearchByNumber(int numberOfFlight) {
            return (FlightNumber == numberOfFlight) ? this : null;
        }

        public IPassenger[] ShowPassengers() {
            IPassenger[] passengers = new IPassenger[(NumberOfEconomySeats + NumberOfBusinessSeats)];
            int i = 0;

            foreach (var ticket in TicketsOfFlight)
            {
                if (ticket.Passenger != null)
                {
                    passengers[i] = ticket.Passenger;
                    i++;
                }
            }

            return passengers;
        }
       
        public ITicket BuyTicket(IPassenger passenger, int numberOfSeat) {
            //ITicket[] freeSeats = new ITicket[TicketsOfFlight.Length];
            //for (int i = 0; i < TicketsOfFlight.Length; i++)
            //{
            //    int j = 0;
            //    if (TicketsOfFlight[i].Passenger == null)
            //    {
            //        freeSeats[j] = TicketsOfFlight[i];
            //        j++;
            //    }
            //}
            foreach (var freeTicket in TicketsOfFlight)
            {
                if (freeTicket.NumberOfSeat == numberOfSeat)
                {
                    freeTicket.BuyTicket(passenger);
                    return freeTicket;
                }
            }
            return null;
        }

        public IPassenger[] SearchByNameLastname(string name) {
            IPassenger[] passengers = new IPassenger[(NumberOfBusinessSeats + NumberOfEconomySeats)];
            int i = 0;
            foreach (var ticket in TicketsOfFlight)
            {
                if (ticket.Passenger != null)
                {
                    if (ticket.Passenger.Firstname.Contains(name))
                    {
                        passengers[i] = ticket.Passenger;
                        i++;
                    } else if (ticket.Passenger.Lastname.Contains(name){
                        passengers[i] = ticket.Passenger;
                        i++;
                    }
                }
            }
            return passengers;
        }

        public IPassenger SearchByPassport(string numberOfPassport) {
            foreach (var ticket in TicketsOfFlight)
            {
                if (ticket.Passenger != null)
                    if (ticket.Passenger.NumberOfPassport.Equals(numberOfPassport))
                        return ticket.Passenger;
            }
            return null;
        }

        public ITicket RefuseFromTicket(int numberOfTicket) {
            foreach (var ticket in TicketsOfFlight)
            {
                if (ticket.Passenger != null)
                    if (ticket.NumberOfTicket == numberOfTicket)
                    {
                        ticket.RefuseFromTicket();
                        return ticket;
                    }
            }
            return null;
        }

        public Flight() { }
        public Flight(string city, int numberOfFlight, int status, DateTime arrivalDepartedTime,
            int terminal, int gate, int numberOfBusinessSeats = 0, int numberOfEconomySeats = 0, decimal priceForBusiness = 0, decimal priceForEconomy = 0) {
            City = city;
            FlightNumber = numberOfFlight;
            FlightStatus = (Status)status;
            ArrivalDeparting = arrivalDepartedTime;
            Terminal = terminal;
            Gate = gate;
            PriceForEconomy = priceForEconomy;
            PriceForBusiness = priceForBusiness;
            NumberOfBusinessSeats = numberOfBusinessSeats;
            NumberOfEconomySeats = numberOfEconomySeats;
            TicketsOfFlight = new ITicket[(numberOfEconomySeats + NumberOfBusinessSeats)];
            for (int i = 0; i < NumberOfBusinessSeats; i++)
            {
                TicketsOfFlight[i] = new Ticket(this, i + 1, (SeatClass)1, PriceForBusiness, i + 1);
            }
            for (int i = NumberOfBusinessSeats; i < TicketsOfFlight.Length; i++)
            {
                TicketsOfFlight[i] = new Ticket(this, i + 1, (SeatClass)2, PriceForEconomy, i + 1);
            }
        }
    }
}
