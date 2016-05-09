using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BA.Airline.Tickets;

namespace BA.Airline.Passengers
{
    enum Sex { Male, Female }
    class Passenger : IPassenger
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nationality { get; set; }
        public string NumberOfPassport { get; set; }
        public DateTime Birthday { get; set; }
       
        public Sex Sex { get; set; }


        public override string ToString() {
            return String.Format("    |{0,-14}|{1,-16}|{2,-10}|{3,-8}|{4,7}|{5,-11}|", Firstname,
                   Lastname, Birthday.ToString("dd-MM-yyyy"), NumberOfPassport, Sex, Nationality);
        }
        public Passenger() { }
        public Passenger(string firstname, string lastname, string nationality, string numberOfPassport,
            DateTime birthday, Sex sex) {
            Firstname = firstname;
            Lastname = lastname;
            Nationality = nationality;
            NumberOfPassport = numberOfPassport;
            Birthday = birthday;
            Sex = sex;
            
        }
    }
}
