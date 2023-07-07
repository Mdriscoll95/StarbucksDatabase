using System;
namespace StarbucksDatabase.Models
{
	public class Sales
	{
        public Sales()
        {
        }
        public int SalesID { get; set; }
		public string StoreName { get; set; }
        public decimal EstimatedAnnualSales { get; set; }
        public decimal SalesByMonth { get; set; }
	}
}

