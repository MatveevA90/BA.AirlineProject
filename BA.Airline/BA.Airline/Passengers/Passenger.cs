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
        Sex _sex;
        public Sex Sex { get; set; }


        public override string ToString() {
            string s = $"Name:{Firstname};\nLastname:{Lastname};\nNationality{Nationality}:\nNumber of passport:{NumberOfPassport};\nBirthday:{Birthday.ToString("dd-MM-yyyy")};\nSex:{Sex.ToString()}";
            return s;
        }
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
