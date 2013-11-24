using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpDataModel
{
    public partial class Player
    {
        public Player(String first, String last, DateTime birth, String rank, string mail,
            string street, string zip, string city, string phone, string phone2, string hash, string license) : this()
        {
            firstName = first;
            lastName = last;
            birthDate = birth;
            ranking = rank;
            email = mail;
            this.street = street;
            zipCode = zip;
            this.city = city;
            phone1 = phone;
            this.phone2 = phone2;
            passwordHash = hash;
            licenceNumber = license;
        }

        public Player(DateTime date, DateTime login)
        {
            birthDate = date;
            lastLogin = login;
        }
    }
}
