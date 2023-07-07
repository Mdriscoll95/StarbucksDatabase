using System;
namespace StarbucksDatabase.Models
{
	public class Stores
	{
		public Stores()
		{
		}
		public int StoreID { get; set; }
		public string Location { get; set; }
		public string Manager { get; set; }
		public int NumberOfEmployees { get; set; }
	}
}

