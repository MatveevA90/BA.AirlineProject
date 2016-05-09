using BA.Airline.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.Airline.ProgramLogic
{
    public class AddFLightClass
    {
        public static void AddFlight(IFlight[] flights, string city, int numberOfFlight, int status,int directionForFlight, DateTime arrivalDepartedTime,
      int terminal, int gate, int numberOfBusinessSeats, int numberOfEconomySeats, decimal priceForBusiness, decimal priceForEconomy) {
            for (int i = 0; i < flights.Length; i++)
            {
                if (flights[i] == null)
                {
                    flights[i] = new Flight(city, numberOfFlight, status, directionForFlight, arrivalDepartedTime,
            terminal, gate, numberOfBusinessSeats, numberOfEconomySeats, priceForBusiness, priceForEconomy);
                }
            }
        }
    }
}
