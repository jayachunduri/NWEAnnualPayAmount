using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayment
{
    public class Address
    {
        #region Properties
        //Create an Address class with properties - Street, HouseNumber, Apartment, Area, Landmark, City, Country, ZipCode
        public string street { get; set; }
        public int houseNumber { get; set; }
        public string apartment { get; set; }
        public string area { get; set; }
        public string landmark { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public int zipcode { get; set; }
        #endregion

        #region Constructors
        public Address()
        {
            this.street = null;
            this.houseNumber = 0;
            this.apartment = null;
            this.area = null;
            this.landmark = null;
            this.city = null;
            this.country = null;
            this.zipcode = 0;
        }

        public Address(string street, int houseNumber, string city, string country, int zip)
        {
            this.street = street;
            this.houseNumber = houseNumber;
            this.city = city;
            this.country = country;
            this.zipcode = zip;
        }
        #endregion
    }
}
