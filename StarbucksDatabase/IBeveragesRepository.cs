using System;
using System.Collections.Generic;
using StarbucksDatabase.Models;
namespace StarbucksDatabase
{
	public interface IBeveragesRepository 
	{
        public IEnumerable<Beverages> GetAllBeverages();
        public Beverages GetBeverages(int id);
        public void UpdateBeverages(Beverages beverages);
        public void InsertBeverages(Beverages beveragesToInsert);
        public void DeleteBeverages(Beverages beverages);
    }
}

