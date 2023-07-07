using System;
namespace StarbucksDatabase.Models
{
	public class Merchandise
	{
		public Merchandise()
		{
		}
		public int MerchandiseID { get; set; }
		public string MerchandiseName { get; set; }
		public string MerchandiseCategory { get; set; }
		public decimal MerchandisePrice { get; set; }
		public int MerchandiseSold { get; set; }
       

    }
}

