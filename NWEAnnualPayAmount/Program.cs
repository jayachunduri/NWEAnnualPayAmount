using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeePayment;

namespace NWEAnnualPayAmount
{
    class Program
    {
        static void Main(string[] args)
        {
            PermanentEmployeePayStub();
            ContractEmployeePayStub();
        }

        public static void PermanentEmployeePayStub()
        {
            //list of orders
            List<Order> orders = new List<Order>();
            orders.Add(new Order(orderDate: new DateTime(2016, 01, 10), productName: "iPhone", quantity: 1, costPerUnit: 300, shipCity: "Pittsburgh", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 01, 21), productName: "toys", quantity: 10, costPerUnit: 30, shipCity: "Denver", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 03, 15), productName: "cloths", quantity: 6, costPerUnit: 15, shipCity: "Orlando", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 04, 1), productName: "computer", quantity: 1, costPerUnit: 900, shipCity: "Taos", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 05, 15), productName: "samsung galaxy S7", quantity: 1, costPerUnit: 400, shipCity: "Colorado Springs", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 05, 17), productName: "iPad", quantity: 1, costPerUnit: 300, shipCity: "Washington DC", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 07, 7), productName: "books", quantity: 20, costPerUnit: 20, shipCity: "Pittsburgh", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 08, 10), productName: "computer", quantity: 1, costPerUnit: 900, shipCity: "Denver", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 09, 30), productName: "toys", quantity: 15, costPerUnit: 20, shipCity: "Detroit", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 10, 10), productName: "cloths", quantity: 14, costPerUnit: 25, shipCity: "Taos", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 12, 10), productName: "Sampung Galaxy S7", quantity: 1, costPerUnit: 400, shipCity: "Pittsburgh", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 12, 10), productName: "iPhone", quantity: 1, costPerUnit: 300, shipCity: "Denver", shipCountry: "USA"));


            //addresses
            Dictionary<addressType, Address> addresses = new Dictionary<addressType, Address>();
            addresses.Add(addressType.home, new Address(street: "North Ridge", houseNumber: 4444, city: "Houston", country: "USA", zip: 80111));
            addresses.Add(addressType.office, new Address(street: "Broad way", houseNumber: 1212, city: "Houston", country: "USA", zip: 80222));
            addresses.Add(addressType.alternative, new Address(street: "South Ridge", houseNumber: 9999, city: "Houston", country: "USA", zip: 80121));

            //Employee working days
            Dictionary<month, int> empWorkingDays = new Dictionary<month, int>() { 
                                                                                                        {month.january, 21}, 
                                                                                                        {month.february, 21},
                                                                                                        {month.march, 22},
                                                                                                        {month.april, 24},
                                                                                                        {month.may, 23},
                                                                                                        {month.june, 24},
                                                                                                        {month.july, 25},
                                                                                                        {month.august, 23},
                                                                                                        {month.september, 24},
                                                                                                        {month.october, 23},
                                                                                                        {month.november, 22},
                                                                                                        {month.december, 15}
            };

            //Create Permenant Employee
            PermanentEmployee pe = new PermanentEmployee(firstName: "Mike", lastName: "Kleir", dateOfBirth: new DateTime(1986, 01, 16), orders: orders, address: addresses, monthlyPackage: 7000, monthlyWorkingDays: empWorkingDays);

            //call print paystun
            pe.PrintAnnualPaySlip(addressType.home);
        }


        public static void ContractEmployeePayStub()
        {
            //list of orders
            List<Order> orders = new List<Order>();
            orders.Add(new Order(orderDate: new DateTime(2016, 01, 10), productName: "iPhone", quantity: 1, costPerUnit: 300, shipCity: "Pittsburgh", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 01, 21), productName: "toys", quantity: 10, costPerUnit: 30, shipCity: "Denver", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 02, 5), productName: "cloths", quantity: 6, costPerUnit: 15, shipCity: "Orlando", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 02, 10), productName: "candels", quantity: 6, costPerUnit: 15, shipCity: "Orlando", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 02, 15), productName: "chairs", quantity: 6, costPerUnit: 15, shipCity: "Orlando", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 03, 15), productName: "cloths", quantity: 6, costPerUnit: 15, shipCity: "Orlando", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 04, 1), productName: "computer", quantity: 1, costPerUnit: 900, shipCity: "Taos", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 05, 15), productName: "samsung galaxy S7", quantity: 1, costPerUnit: 400, shipCity: "Colorado Springs", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 05, 17), productName: "iPad", quantity: 1, costPerUnit: 300, shipCity: "Washington DC", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 07, 7), productName: "books", quantity: 20, costPerUnit: 20, shipCity: "Pittsburgh", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 07, 15), productName: "cloths", quantity: 6, costPerUnit: 15, shipCity: "Orlando", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 08, 15), productName: "cloths", quantity: 6, costPerUnit: 15, shipCity: "Orlando", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 08, 10), productName: "computer", quantity: 1, costPerUnit: 900, shipCity: "Denver", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 09, 30), productName: "toys", quantity: 15, costPerUnit: 20, shipCity: "Detroit", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 10, 10), productName: "cloths", quantity: 14, costPerUnit: 25, shipCity: "Taos", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 12, 10), productName: "Sampung Galaxy S7", quantity: 1, costPerUnit: 400, shipCity: "Pittsburgh", shipCountry: "USA"));
            orders.Add(new Order(orderDate: new DateTime(2016, 12, 10), productName: "iPhone", quantity: 1, costPerUnit: 300, shipCity: "Denver", shipCountry: "USA"));


            //addresses
            Dictionary<addressType, Address> addresses = new Dictionary<addressType, Address>();
            addresses.Add(addressType.home, new Address(street: "Shady Lane", houseNumber: 4444, city: "LosAngels", country: "USA", zip: 80111));
            addresses.Add(addressType.office, new Address(street: "Broad way", houseNumber: 1212, city: "LosAngels", country: "USA", zip: 80222));
            addresses.Add(addressType.alternative, new Address(street: "Chatham Park Dr", houseNumber: 9999, city: "LosAngels", country: "USA", zip: 80121));

            //Create Permenant Employee
            ContractEmployee ce = new ContractEmployee(firstName: "Kris", lastName: "Borich", dateOfBirth: new DateTime(1984, 01, 16), orders: orders, address: addresses, monthlyContractAmount: 5000);

            //call print paystun
            ce.PrintAnnualPaySlip(addressType.office);
        }
    } 
}
