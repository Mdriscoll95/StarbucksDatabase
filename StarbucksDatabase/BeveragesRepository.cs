using System;
using System.Data;
using Dapper;
using StarbucksDatabase.Models;

namespace StarbucksDatabase
{
	public class BeveragesRepository : IBeveragesRepository
	{
		private readonly IDbConnection? _conn;

        public BeveragesRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Beverages> GetAllBeverages()
        {
            return _conn.Query<Beverages>("SELECT * FROM BEVERAGES;");
        }

        public BeveragesRepository()
		{

		}
        public Beverages GetBeverages(int id)
        {
            return _conn.QuerySingle<Beverages>("SELECT * FROM Beverages WHERE idBeverages = @id", new { id = id });
        }
        public void UpdateBeverages(Beverages beverages) 
        {
            _conn.Execute("UPDATE Beverages SET BeverageName = @name, BeveragesSold = @sold, BeveragePrice = @price WHERE idBeverages = @id",
             new { name = beverages.BeverageName, sold = beverages.BeveragesSold, price = beverages.BeveragePrice, id = beverages.idBeverages });
        }
        public void InsertBeverages(Beverages beveragesToInsert)
        {
            _conn.Execute("INSERT INTO beverages (BeverageNAME, BeveragePRICE, idBeverages, BeveragesSold) VALUES (@name, @price, @categoryID, @sold);",
                new { name = beveragesToInsert.BeverageName, price = beveragesToInsert.BeveragePrice, categoryID = beveragesToInsert.idBeverages, sold = beveragesToInsert.BeveragesSold });
        }
        public void DeleteBeverages(Beverages beverages)
        {
            _conn.Execute("DELETE FROM Beverages WHERE idBeverages = @id;", new { id = beverages.idBeverages });
            _conn.Execute("DELETE FROM Beverages WHERE BeverageName = @name;", new { name = beverages.BeverageName });
            _conn.Execute("DELETE FROM Beverages WHERE BeveragesSold = @sold;", new { sold = beverages.BeveragesSold });
            _conn.Execute("DELETE FROM Beverages WHERE BeveragePrice = @price;", new { price = beverages.BeveragePrice });
        }
    }
}

