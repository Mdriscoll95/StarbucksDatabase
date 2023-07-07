using System;
using System.Data;
using Dapper;
using StarbucksDatabase.Models;

namespace StarbucksDatabase
{
	public class MerchandiseRepository : IMerchandiseRepository
	{
        private readonly IDbConnection _conn;

        public MerchandiseRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Merchandise> GetAllMerchandise()
        {
            return _conn.Query<Merchandise>("SELECT * FROM Merchandise;");
        }
        public Merchandise GetMerchandise(int id)
        {
            return _conn.QuerySingle<Merchandise>("SELECT * FROM Merchandise WHERE MerchandiseID = @id", new { id = id });
        }

        
        public void UpdateMerchandise(Merchandise merchandise)
        {
            _conn.Execute("UPDATE Merchandise SET MerchandiseName = @name, MerchandiseCategory = @category, MerchandisePrice = @price, MerchandiseSold = @sold WHERE MerchandiseID = @id",
             new { name = merchandise.MerchandiseName, category = merchandise.MerchandiseCategory, price = merchandise.MerchandisePrice, sold = merchandise.MerchandiseSold, id = merchandise.MerchandiseID });
        }
        public void InsertMerchandise(Merchandise merchandiseToInsert)
        {
            _conn.Execute("INSERT INTO Merchandise (MerchandiseNAME, MerchandiseCATEGORY, MerchandisePRICE, MerchandiseSOLD) VALUES (@name, @category, @price, @sold);",
                new { name = merchandiseToInsert.MerchandiseName, category = merchandiseToInsert.MerchandiseCategory, price = merchandiseToInsert.MerchandisePrice, sold = merchandiseToInsert.MerchandiseSold });
        }
        public void DeleteMerchandise(Merchandise merchandise)
        {
            _conn.Execute("DELETE FROM Merchandise WHERE MerchandiseID = @id;", new { id = merchandise.MerchandiseID });
        }
    }
}

