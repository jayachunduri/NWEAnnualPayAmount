using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayment
{
    public class ContractEmployee: Employee
    {
        #region Properties
        public decimal monthlyContractAmount;
        private static int minimumOrderThreshold = 2;
        private const decimal _COMMISSION = 0.1M;
        //public Dictionary<string, int> monthlyOrderThreshold;

        #endregion

        #region Constructors
        public ContractEmployee()
        {
            monthlyContractAmount = 0;
            
        }

        public ContractEmployee(string firstName, string lastName, DateTime dateOfBirth, List<Order> orders, Dictionary<addressType, Address> address, decimal monthlyContractAmount):
            base(firstName, lastName, dateOfBirth, orders, address)
        {
            this.monthlyContractAmount = monthlyContractAmount;
            
        }

        #endregion

        #region Methods
        public override decimal CalculateCommission(month month)
        {
            decimal commissionForMonth = 0;

            //
            List<Order> ordersForMonth = orders.Where(x => x.monthOfTheOrder == month.ToString().ToLower()).ToList();
            
            foreach(Order order in ordersForMonth)
            {
                //need to get total price
                decimal totalPrice = order.quantity * order.costPerUnit;
                commissionForMonth += (totalPrice * _COMMISSION);
            }
            return commissionForMonth;
        }

        public override decimal CalculateSalary(month month)
        {
            decimal monthlySalary = 0;

            //check if emp meet minimum thereshold
            List<Order> ordersForMonth = orders.Where(x => x.monthOfTheOrder == month.ToString().ToLower()).ToList();

            if(ordersForMonth.Count() >= minimumOrderThreshold)
            {
                monthlySalary = monthlyContractAmount;
            }
            else
            {
                monthlySalary = Math.Round(monthlyContractAmount * (decimal)0.8);
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
                foreach (month mn in Enum.GetValues(typeof(month)))
                    {
                        decimal monthlySalary = CalculateSalary((month)mn);
                        sw.WriteLine((month) mn + ": " + monthlySalary);
                        annualSalary += monthlySalary;
                    }
                sw.WriteLine("Annual Salary: " + annualSalary);

                //print commission for each month
                sw.WriteLine("***********************************************************");
                sw.WriteLine("***********************************************************");
                sw.WriteLine("Commission Details");
                foreach (month mn in Enum.GetValues(typeof(month)))
                {
                    decimal monthlyCommission = CalculateCommission((month)mn);
                    sw.WriteLine((month)mn + ": " + monthlyCommission);
                    annualCommission += monthlyCommission;
                }
                sw.WriteLine("Annual Commission: " + annualCommission);
            }

        }
        #endregion
    }
}
