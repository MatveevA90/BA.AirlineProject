using BA.Airline.Flights;
using BA.Airline.Flights.Comparers;
using BA.Airline.Passengers;
using BA.Airline.ProgramLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.Airline
{
    class Program
    {
        static void Main(string[] args) {
            Console.SetWindowSize(200, 60);
            const int maxFlight = 10;
            Flight[] flights = new Flight[maxFlight];
            flights[0] = new Flight("Kiev", 576, 4, 1, new DateTime(2016, 7, 8, 18, 50, 0), 5, 3, 30, 100, 250m, 120m);
            flights[1] = new Flight("Berlin", 333, 1, 2, new DateTime(2016, 7, 15, 16, 0, 0), 1, 5, 0, 300, 0, 100m);
            flights[2] = new Flight("Rome", 789, 6, 1, new DateTime(2016, 7, 23, 23, 30, 0), 4, 2, 100, 400, 500, 175);
            Passenger passenger1 = new Passenger("Ivan", "Ivanov", "USA", "12354654", new DateTime(1990, 2, 19), 0);
            Passenger passenger2 = new Passenger("Piter", "Petrov", "Ukraine", "999999", new DateTime(1989, 5, 5), 0);
            Passenger passenger3 = new Passenger("Anna", "Sidorova", "Russia", "999999", new DateTime(1980, 5, 12), (Sex)1);
            flights[0].BuyTicket(passenger1, 12);
            flights[1].BuyTicket(passenger2, 150);
            flights[2].BuyTicket(passenger3, 350);

            try
            {
                do
                {
                    int a;
                    Console.Clear();
                    MainMenu.ShowFlightTable(flights);
                    Console.WriteLine();
                    Console.WriteLine(@"Please,  type the number:
                    1.  View all flights
                    2.  View all flight’s passengers 
                    3.  Add flight
                    4.  Edit flight info
                    5.  Delet flight
                    6.  Passengers menu
          
                    ");
                    try
                    {
                        int number;
                        a = (int)uint.Parse(Console.ReadLine());
                        switch (a)
                        {
                            case 1:
                                Console.Clear();
                                Array.Sort(flights);
                                MainMenu.ShowFlightTable(flights);
                                break;
                            case 2:
                                Console.Clear();
                                Array.Sort(flights, new FlightNumberComparer());
                                MainMenu.ShowFlightTable(flights);
                                Console.Write("Enter number of flight:");
                                number = int.Parse(Console.ReadLine());
                                MainMenu.ShowAllPassengersInFlight(flights, number);
                                break;
                            case 3:
                                Console.Clear();
                                MainMenu.AddFlight(flights);
                                Console.Clear();
                                MainMenu.ShowFlightTable(flights);
                                break;
                            case 4:
                                Console.Clear();
                                MainMenu.ShowFlightTable(flights);
                                Console.Write("Enter number of flight:");
                                number = int.Parse(Console.ReadLine());
                                Console.Clear();
                                if (MainMenu.SearchByNumber(flights, number) != null)
                                {
                                    Console.WriteLine(MainMenu.SearchByNumber(flights, number));
                                    MainMenu.EditFlight(MainMenu.SearchByNumber(flights, number));
                                    Console.Clear();
                                    MainMenu.ShowFlightTable(flights);
                                } else
                                    Console.WriteLine("No flight with this number!");
                                break;
                            case 5:
                                Console.Clear();
                                MainMenu.ShowFlightTable(flights);
                                Console.Write("Enter number of flight:");
                                number = int.Parse(Console.ReadLine());
                                Console.Clear();
                                if (MainMenu.SearchByNumber(flights, number) != null)
                                {
                                    Console.WriteLine(MainMenu.SearchByNumber(flights, number));
                                    MainMenu.DeletFlight(flights, number);
                                    Console.Clear();
                                    MainMenu.ShowFlightTable(flights);
                                } else
                                    Console.WriteLine("No flight with this number!");
                                break;
                            case 6:
                                PassengerManu.ShowPassengerMenu(flights);
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



            Console.ReadLine();
        }
    }
}
