using System;
namespace StarbucksDatabase.Models
{
	public class Beverages
	{
		public Beverages()
		{
		}
		public int idBeverages { get; set; }
		public string BeverageName { get; set; }
		public int BeveragesSold { get; set; }
		public decimal BeveragePrice { get; set; }
	}
}

