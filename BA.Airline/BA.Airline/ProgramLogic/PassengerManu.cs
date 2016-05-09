using BA.Airline.Flights;
using BA.Airline.Flights.Comparers;
using BA.Airline.Passengers;
using BA.Airline.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.Airline.ProgramLogic
{
    class PassengerManu
    {
        public static void ShowPassengerMenu(IFlight[] flights) {
            Console.Clear();
            try
            {
                do
                {
                    int a;

                    Console.WriteLine();
                    Console.WriteLine(@"Please,  type the number:
                    1.  Buy ticket
                    2.  Refuse from ticket
                    3.  Search by cost of ticket
                   
                    ");
                    try
                    {
                        int number;
                        a = (int)uint.Parse(Console.ReadLine());
                        switch (a)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Enter number of flight:");
                                int flightNumber = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter number of seat:");
                                int seatNumber = int.Parse(Console.ReadLine());
                                Passenger passenger = new Passenger();
                                Console.WriteLine("Enter name of passenger:");
                                passenger.Firstname = Console.ReadLine();
                                Console.WriteLine("Enter lastname of passenger:");
                                passenger.Lastname = Console.ReadLine();
                                Console.WriteLine("Enter number of passenger's passport:");
                                passenger.NumberOfPassport = Console.ReadLine();
                                Console.WriteLine("Enter nationality of passenger:");
                                passenger.Nationality = Console.ReadLine();
                                Console.WriteLine("Enter Birthday of passenger(dd - MM - yyyy):");
                                passenger.Birthday = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("Enter sex of passenger(Male - 0 ,Female - 1):");
                                passenger.Sex = (Sex)int.Parse(Console.ReadLine());
                                PassengerManu.BuyTicket(flights, flightNumber, seatNumber, passenger);
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Enter number of ticket:");
                                string numberOfTicket = Console.ReadLine();
                                IPassenger passenger1 = null;
                                ITicket ticket = null;
                                foreach (var flight in flights)
                                {
                                    
                                    if (flight.SearchByNumberOfTicket(numberOfTicket) != null)
                                    {
                                        passenger1 = flight.SearchByNumberOfTicket(numberOfTicket);
                                    }
                                }
                                
                                PassengerManu.RefuseFromTicket(flights, ticket, passenger1);
                                break;
                            case 3:
                                Console.Clear();
                                Array.Sort(flights, new PriceComparer());
                                MainMenu.ShowFlightTable(flights);
                                Console.WriteLine();
                                Console.WriteLine("Enter the highest cost of ticket:");
                                decimal money = decimal.Parse(Console.ReadLine());
                                Console.WriteLine();
                                if (PassengerManu.SearchByMoney(flights, money) != null)
                                {
                                    foreach (var flight in PassengerManu.SearchByMoney(flights, money))
                                        Console.WriteLine(flight);
                                } else
                                    Console.WriteLine("No flight with such ticket price!");
                                break;

                            default:
                                break;
                        }


                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Eror!");
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Press Spacebar to exit; press any key to continue");
                    Console.ForegroundColor = ConsoleColor.White;
                } while (Console.ReadKey().Key != ConsoleKey.Spacebar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void BuyTicket(IFlight[] flights, int numberOfFlight, int numberOfSeat, IPassenger passenger) {
            foreach (var flight in flights)
            {
                if (flight.SearchByNumber(numberOfFlight) != null)
                {
                    flight.SearchByNumber(numberOfFlight).BuyTicket(passenger, numberOfSeat);
                    break;
                }
            }
            throw new Exception();
        }
        public static void RefuseFromTicket(IFlight[] flights, ITicket ticket, IPassenger passenger) {
            foreach (var flight in flights)
            {
                if (flight.SearchByNumberOfTicket(ticket.NumberOfTicket) == passenger)
                {
                    flight.RefuseFromTicket(ticket.NumberOfTicket, passenger);
                    break;
                }
            }
            throw new Exception();
        }
        public static IFlight[] SearchByMoney(IFlight[] flights, decimal money) {
            IFlight[] foundFlights = new IFlight[flights.Length];
            int i = 0;
            foreach (var flight in flights)
            {
                foundFlights[i++] = flight.SearchByCost(money);
            }
            return foundFlights;
        }
    }
}
