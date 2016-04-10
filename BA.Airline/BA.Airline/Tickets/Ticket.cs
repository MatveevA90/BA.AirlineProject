using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BA.Airline.Passengers;
using BA.Airline.Flights;

namespace BA.Airline.Tickets
{
    public enum SeatClass { Business=1, Economy }
    class Ticket : ITicket
    {
        public IFlight Flight { get; set; }


        public int NumberOfTicket { get; set; }
        SeatClass _seatClass;
        public SeatClass ClassOfSeat { get; set; }
        decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value <= 0) throw new NullReferenceException();
                else _price = value;
            }
        }
        public int NumberofSeat { get; set; }
        IPassenger _passenger = null;
        public IPassenger Passenger { get; set; }

        public void BuyTicket(IPassenger passenger) {
            Passenger = passenger;
        }

        public void PrintTicket() {
            Console.WriteLine($"--------------{NumberOfTicket}---------------");
            Console.WriteLine($"Number of flight:{ Flight.FlightNumber.ToString()}");
            Console.WriteLine($"Number of ticket: {Flight.FlightNumber.ToString()}.{NumberOfTicket}");
            Console.WriteLine($"Class:{ClassOfSeat.ToString()}");
            Console.WriteLine($"Price:{Price.ToString()}");
        }

        public void RefuseFromTicket() {
            Passenger = null;
        }

        public IPassenger ShowOwner() {
            return Passenger;
        }

        public Ticket(IFlight flight, int numberOfTicket, SeatClass seatClass, decimal price, int numberOfSeat) {
            Flight = flight;
            NumberOfTicket = numberOfTicket;
            ClassOfSeat = seatClass;
            Price = price;
            NumberofSeat = numberOfSeat;
        }
    }
}
