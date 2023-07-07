using System;
using StarbucksDatabase.Models;

namespace StarbucksDatabase
{
	public interface ISalesRepository
	{
        public IEnumerable<Sales> GetAllSales();
        public Sales GetSales(int id);
        public void UpdateSales(Sales sales);
        public void InsertSales(Sales salesToInsert);
        public void DeleteSales(Sales sales);
    }
}

