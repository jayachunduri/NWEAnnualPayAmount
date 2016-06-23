using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayment
{
    public class PermanentEmployee : Employee
    {
        #region Properties
        public decimal monthlyPackage { get; set; }
        public Dictionary<month, int> employeeWorkingDays { get; set; }
        public static Dictionary<month, int> WORKING_DAYS_FORMONTH = new Dictionary<month, int>() { 
                                                                                                        {month.january, 23}, 
                                                                                                        {month.february, 23},
                                                                                                        {month.march, 24},
                                                                                                        {month.april, 25},
                                                                                                        {month.may, 23},
                                                                                                        {month.june, 24},
                                                                                                        {month.july, 25},
                                                                                                        {month.august, 23},
                                                                                                        {month.september, 25},
                                                                                                        {month.october, 24},
                                                                                                        {month.november, 23},
                                                                                                        {month.december, 20}
                                                                                                    }; 
        //static const int TOTAL_WORKINGDAYS_FORYEAR = 250; //some number
        const decimal COMMISSION = 0.05M;
        #endregion

        #region Constructors
        public PermanentEmployee(): base()
        {
            this.monthlyPackage = 0;
            this.employeeWorkingDays = null;

        }

        public PermanentEmployee(string firstName, string lastName, DateTime dateOfBirth, List<Order> orders, Dictionary<addressType, Address> address, decimal monthlyPackage, Dictionary<month, int> monthlyWorkingDays):
            base(firstName, lastName, dateOfBirth, orders, address)
        {
            this.monthlyPackage = monthlyPackage;
            this.employeeWorkingDays = monthlyWorkingDays;
        }

        #endregion

        #region Methods
        public override decimal CalculateCommission(month month)
        {
            //Commission for each order for permanent employee = 5% on each order amount
            decimal commissionForMonth = 0;
           
            //need to get orders for that month
            List<Order> ordersForMonth = orders.Where(x => x.monthOfTheOrder == month.ToString().ToLower()).ToList();
            
            //loop through those orders to calculate commission
            foreach(Order order in ordersForMonth)
            {
                //need to get total price
                decimal totalPrice = order.quantity * order.costPerUnit;
                commissionForMonth += (totalPrice * COMMISSION);
            }

            return Math.Round(commissionForMonth);
        }

        public override decimal CalculateSalary(month month)
        {
            decimal monthlySalary = 0;
            int monthlyWorkingDays = 0;
            int monthlyEmpWorkingDays =  0;

            if ((employeeWorkingDays.TryGetValue(month, out monthlyEmpWorkingDays)) && (WORKING_DAYS_FORMONTH.TryGetValue(month, out monthlyWorkingDays)))
            {
                monthlySalary = Math.Round(((decimal)(monthlyEmpWorkingDays)/(decimal)(monthlyWorkingDays)) * monthlyPackage);
            }
            else
            {
                monthlySalary = 0;
            }
            return monthlySalary;
        }

        public override void PrintAnnualPaySlip(addressType typeOfAddress)
        {
            base.PrintAnnualPaySlip(typeOfAddress);
            string fileName = this.firstName + this.lastName + this.empId + ".txt";
            string pathString = System.IO.Path.Combine(@"C:\Users\hopdizzle\Documents\Jaya\ProfessionalGuru\EmpAnnualPayStubs", fileName);

            decimal annualCommission = 0;
            decimal annualSalary = 0;         
                     
            using (StreamWriter sw = File.AppendText(pathString))
            {
                //print salary for each month
                foreach(KeyValuePair<month, int> kvp in WORKING_DAYS_FORMONTH)
                {
                    decimal monthlySalary = CalculateSalary(kvp.Key);
                    sw.WriteLine(kvp.Key + ": " + monthlySalary);
                    annualSalary += monthlySalary;
                }
                sw.WriteLine("Annual Salary: " + annualSalary);

                //print commission for each month
                sw.WriteLine("***********************************************************");
                sw.WriteLine("***********************************************************");
                sw.WriteLine("Commission Details");
                foreach (KeyValuePair<month, int> kvp in WORKING_DAYS_FORMONTH)
                {
                    decimal monthlyCommission = CalculateCommission(kvp.Key);
                    sw.WriteLine(kvp.Key + ": " + monthlyCommission);
                    annualCommission += monthlyCommission;
                }
                sw.WriteLine("Annual Commission: " + annualCommission);
            }

        }
        #endregion
    }

    
}
