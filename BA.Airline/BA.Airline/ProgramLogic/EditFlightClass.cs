using BA.Airline.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.Airline.ProgramLogic
{
    class EditFlightClass
    {
        public static void EditFlight(IFlight flight) {
            do
            {
                Console.WriteLine(flight.ToString());
                int a;
                Console.WriteLine(@"Please, type the number to edit:
                1.Edit direction for flight
                2.Edit flight city
                3.Edit flight number
                4.Edit direction for flight
                5.Edit flight status
                6.Edit time of flight
                7.Edit number of bussiness seats
                8.Edit number of economy seats 
                9.Edit price of bussines seat
                10.Edit price of economy seat");
                try
                {
                    a = (int)uint.Parse(Console.ReadLine());
                    switch (a)
                    {
                        case 1:
                            Console.WriteLine("Enter the direction of flight(Arrived - 1,Departed - 2)");
                            flight.EditDirectionForFlight(int.Parse(Console.ReadLine()));
                            break;
                        case 2:
                            Console.WriteLine("Enter the flight city:");
                            flight.EditFlightCity(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("Enter flight number:");
                            flight.EditFlightNumber(int.Parse(Console.ReadLine()));
                            break;
                        case 4:
                            Console.WriteLine("Enter the flight direction(Arrived = 1, Departed  = 2):");
                            flight.EditDirectionForFlight(int.Parse(Console.ReadLine()));
                            break;

                        case 5:
                            Console.WriteLine(@"Enter the flight status(Chek In = 1, Gate Closed = 2, 
                                   Unknown = 3, Canceled = 4,  Expected At = 5, Delayed = 6, In Flight = 7):");
                            flight.EditFlightStatus(int.Parse(Console.ReadLine()));
                            break;
                        case 6:
                            Console.WriteLine("New time of arrival is(YYYY:MM:DD hh:mm): ");
                            flight.EditFlightArrivalDeparting(DateTime.Parse(Console.ReadLine()));
                            break;
                        case 7:
                            int counter = 0;
                            foreach (var ticket in flight.TicketsOfFlight)
                            {
                                if (ticket.Passenger != null && (int)ticket.ClassOfSeat == 1)
                                    counter++;
                            }
                            Console.WriteLine($"Enter number of bussiness seats(no lower than {counter})");
                            flight.EditFlightNumberOfBusinessSeats(int.Parse(Console.ReadLine()));
                            Console.WriteLine($"Number of bussiness seats are {flight.NumberOfBusinessSeats}");
                            break;
                        case 8:
                            int economyCounter = 0;
                            foreach (var ticket in flight.TicketsOfFlight)
                            {
                                if (ticket.Passenger != null && (int)ticket.ClassOfSeat == 2)
                                    economyCounter++;
                            }
                            Console.WriteLine($"Enter number of economy seats(no lower than {economyCounter})");
                            flight.EditFlightNumberOfEconomySeats(int.Parse(Console.ReadLine()));
                            Console.WriteLine($"Number of economy seats are {flight.NumberOfBusinessSeats}");
                            break;
                        case 9:
                            Console.WriteLine("Enter price of bussines seat: ");
                            flight.EditFlightPriceOfBussinesSeat(decimal.Parse(Console.ReadLine()));
                            break;
                        case 10:
                            Console.WriteLine("Enter price of economy seat: ");
                            flight.EditFlightPriceOfEconomySeat(decimal.Parse(Console.ReadLine()));
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error" + e.ToString());
                }
                Console.WriteLine("Press Spacebar to exit; press any key to continue");
            } while (Console.ReadKey().Key != ConsoleKey.Spacebar);
        }
    }
}
