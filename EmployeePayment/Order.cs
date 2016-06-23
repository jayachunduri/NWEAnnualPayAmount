using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayment
{
    public class Order
    {
        #region Properties
        //Create an Order class - int OrderId, OrderDate, ProductName, Quantity, CostPerUnit, ShipCity, ShipCountry, bool IsOrderConfirmed
        private static int _previousOrderId = 1;
        public int orderId { get; set; }
        public DateTime? orderDate { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public decimal costPerUnit { get; set; }
        public string shipCity { get; set; }
        public string shipCountry { get; set; }
        public bool isOrderConfirmed { get; set; }

        public string monthOfTheOrder { get; set; }
        #endregion

        #region Constructors
        //public Order()
        //{
        //    this.orderId = 0;
        //    this.orderDate = null;
        //    this.productName = null;
        //    this.quantity = 0;
        //    this.costPerUnit = 0;
        //    this.shipCity = null;
        //    this.shipCountry = null;
        //    this.isOrderConfirmed = false;
        //}

        public Order(DateTime orderDate, string productName, int quantity, decimal costPerUnit, string shipCity, string shipCountry)
        {
            this.orderId = _previousOrderId++;
            this.orderDate = orderDate;
            this.productName = productName;
            this.quantity = quantity;
            this.costPerUnit = costPerUnit;
            this.shipCity = shipCity;
            this.shipCountry = shipCountry;
            this.isOrderConfirmed = true;
            //this.monthOfTheOrder = orderDate.Month.ToString("MMMM");
            this.monthOfTheOrder = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(orderDate.Month).ToLower();
        }
        #endregion
    }
}
