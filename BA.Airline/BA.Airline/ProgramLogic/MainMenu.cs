using BA.Airline.Flights;
using BA.Airline.Flights.Comparers;
using BA.Airline.Passengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.Airline.ProgramLogic
{
    public class MainMenu
    {
        public static void ShowFlightTable(IFlight[] flights) {
            Console.WriteLine("|Direction|    Date/Time   |Number|     City      |Terminal/Gate|  Status  |Free places|");
            foreach (var flight in flights)
            {
                if (flight != null)
                {
                    Console.WriteLine("----------------------------------------------------------------------------------------");
                    Console.WriteLine(flight);
                }
            }
            Console.WriteLine("----------------------------------------------------------------------------------------");
        }
        public static void ShowAllPassengersInFlight(IFlight[] flights, int numberOfFlight) {
            foreach (var flight in flights)
            {
                Console.WriteLine("|   |   FirsName   |    LastName    | Birthday |Passport|  Sex  |Nationality|");
                if (flight.SearchByNumber(numberOfFlight) != null)
                    foreach (var passenger in flight.ShowPassengers())
                    {
                        if (passenger.NumberOfPassport != null)
                        {
                            Console.WriteLine("---------------------------------------------------------------------------");
                            Console.WriteLine(passenger);
                        }
                    }
            }
        }
        public static void DeletFlight(IFlight[] flights, int numberOfFlight) {
            foreach (var flight in flights)
            {
                flight.DeletFlight(numberOfFlight);
            }
        }
        public static void AddFlight(IFlight[] flights) {
            int a;
            try
            {
                Console.WriteLine("Please,enter number of flight:");
                int numberOfFlight = int.Parse(Console.ReadLine());
                Console.WriteLine("Please,enter city of flight:");
                string city = Console.ReadLine();
                Console.WriteLine(@"Please, enter the flight status(Chek In = 1, Gate Closed = 2,
                                    Unknown = 3, Canceled = 4,Expected At = 5, Delayed = 6, In Flight = 7):");
                int status = int.Parse(Console.ReadLine());
                Console.WriteLine("Please, enter the flight direction(Arrived = 1, Departed  = 2):");
                int directionForFlight = int.Parse(Console.ReadLine());
                Console.WriteLine("New time of arrival is(YYYY:MM:DD hh:mm): ");
                DateTime arrivalDepartedTime = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Please,enter terminal of flight:");
                int terminal = int.Parse(Console.ReadLine());
                Console.WriteLine("Please,enter gate of flight:");
                int gate = int.Parse(Console.ReadLine());
                Console.WriteLine("Please,enter number of business seats:");
                int numberOfBusinessSeats = int.Parse(Console.ReadLine());
                decimal priceForBusiness;
                if (numberOfBusinessSeats > 0)
                {
                    Console.WriteLine("Please,enter price of business seats:");
                    priceForBusiness = decimal.Parse(Console.ReadLine());
                } else
                { priceForBusiness = 0; }
                Console.WriteLine("Please,enter number of economy seats:");
                int numberOfEconomySeats = int.Parse(Console.ReadLine());
                decimal priceForEconomy = 0;
                if (numberOfEconomySeats > 0)
                {
                    Console.WriteLine("Please,enter price of business seats:");
                    priceForEconomy = decimal.Parse(Console.ReadLine());
                } else
                { priceForEconomy = 0; }
                AddFLightClass.AddFlight(flights, city, numberOfFlight, status, directionForFlight, arrivalDepartedTime,
                terminal, gate, numberOfBusinessSeats, numberOfEconomySeats, priceForBusiness, priceForEconomy);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.ToString());
            }

        }
        
        
        public static void EditFlight(IFlight flight) {
            EditFlightClass.EditFlight(flight);
        }
        public static IFlight SearchByNumber(IFlight[] flights, int numberOfFlight) {
            foreach (var flight in flights)
            {
                if (flight.SearchByNumber(numberOfFlight) != null)
                    return flight;
            }
            throw new ArgumentException();
        }
        public static void SearchByNameLastname(IFlight[] flights, string name) {
            IPassenger[][] passengers = new IPassenger[flights.Length][];
            int i = 0;
            foreach (var flight in flights)
            {
                if (flight.SearchByNameLastname(name) != null)
                {
                    passengers[i] = flight.SearchByNameLastname(name);
                    i++;
                }
            }
            foreach (var passenger in passengers)
            {
                foreach (var item in passenger)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
        public static void SearchByPassport(IFlight[] flights, int numberOfPassport) {
            IPassenger[] passengers = new IPassenger[100];
            int i = 0;
            foreach (var flight in flights)
            {
                if (flight.SearchByPassport(numberOfPassport.ToString()) != null)
                {
                    passengers[i++] = flight.SearchByPassport(numberOfPassport.ToString());

                }
            }
            if (passengers != null)
            {
                foreach (var passenger in passengers)
                {
                    if (passenger != null)
                        Console.WriteLine(passenger);
                }
            } else
                Console.WriteLine($"No passenger with such passport: {numberOfPassport}");

        }
        
    }
}
