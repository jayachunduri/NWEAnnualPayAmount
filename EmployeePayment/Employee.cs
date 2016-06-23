using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.SqlServer.Management.Smo;

namespace EmployeePayment
{
    public abstract class Employee
    {
        #region Properties
        private static int _previousEmpId = 100;
        public int empId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public List<Order> orders { get; set; }
        public Dictionary<addressType, Address> address { get; set; } //to have residence address, home address, alternate address, etc.


        #endregion

        #region Constructors

        public Employee()
        {
            this.empId = 0;
            this.firstName = "";
            this.lastName = "";
            this.dateOfBirth = null;
            this.orders = null;
            this.address = null;

        }

        public Employee(string firstName, string lastName, DateTime dateOfBirth, List<Order> orders, Dictionary<addressType, Address> address)
        {
            this.empId = _previousEmpId++;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.orders = orders;
            this.address = address;
        }
        #endregion

        #region Methods

        public abstract decimal CalculateCommission(month month);

        public abstract decimal CalculateSalary(month month);

        public virtual void PrintAnnualPaySlip(addressType typeOfAddress)
        {
            //create folder and file
            string fileName = this.firstName + this.lastName + this.empId +".txt";
            string pathString = System.IO.Path.Combine(@"C:\Users\hopdizzle\Documents\Jaya\ProfessionalGuru\EmpAnnualPayStubs", fileName);
            Address employeeAddress = new Address();

            //prepate text to write into file
            List<string> lines = new List<string>();

            lines.Add("***********************************************************");
            lines.Add("Employee Details");
            lines.Add("Employee First Name: " + this.firstName);
            lines.Add("Employee Last Name: " + this.lastName);
            if (this.address.TryGetValue(typeOfAddress, out employeeAddress))
            {
                lines.Add("Employee " + typeOfAddress + " Address: " + employeeAddress.street +", " +employeeAddress.houseNumber);
                lines.Add("                  "+employeeAddress.city + ", " + employeeAddress.zipcode + ", " + employeeAddress.country);
            }
            else
            {
                lines.Add("No Address on record");
            }
            lines.Add("Employee ID: " + this.empId);
            lines.Add("***********************************************************");
            lines.Add("***********************************************************");
            lines.Add("Salary Details");
            
            File.WriteAllLines(pathString, lines);
        }
        #endregion
    }

    //enum for address types
    public enum addressType: int
    {
        home, office, alternative
    }

    public enum month: int
    {
        january, february, march, april, may, june, july, august, september, october, november, december
    }
}
