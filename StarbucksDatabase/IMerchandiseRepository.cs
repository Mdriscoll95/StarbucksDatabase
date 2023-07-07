using System;
using StarbucksDatabase.Models;

namespace StarbucksDatabase
{
	public interface IMerchandiseRepository
	{
        public IEnumerable<Merchandise> GetAllMerchandise();
        public Merchandise GetMerchandise(int id);
        public void UpdateMerchandise(Merchandise merchandise);
        public void InsertMerchandise(Merchandise merchandiseToInsert);
        public void DeleteMerchandise(Merchandise merchandise);
    }

}

