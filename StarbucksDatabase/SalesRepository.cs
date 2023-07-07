using System;
using System.Data;
using Dapper;
using StarbucksDatabase.Models;

namespace StarbucksDatabase
{
	public class SalesRepository : ISalesRepository
	{
        private readonly IDbConnection _conn;

        public SalesRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Sales> GetAllSales()
        {
            return _conn.Query<Sales>("SELECT * FROM Sales;");
        }

        public Sales GetSales(int id)
        {
            return _conn.QuerySingle<Sales>("SELECT * FROM Sales WHERE SalesID = @id", new { id = id });
        }

        public void UpdateSales(Sales sales)
        {
            _conn.Execute("UPDATE Sales SET StoreName = @name, EstimatedAnnualSales = @EstimatedAnnualSales, SalesByMonth = @SalesByMonth WHERE SalesID = @id",
             new { name = sales.StoreName, sales.EstimatedAnnualSales, sales.SalesByMonth, id = sales.SalesID });
        }

        public void InsertSales(Sales salesToInsert)
        {
            _conn.Execute("INSERT INTO sales (StoreName, EstimatedAnnualSales, SalesByMonth) VALUES (@name, @estimatedAnnualSales, @salesByMonth);",
                new { name = salesToInsert.StoreName, estimatedAnnualSales = salesToInsert.EstimatedAnnualSales,salesByMonth = salesToInsert.SalesByMonth });
        }

        public void DeleteSales(Sales sales)
        {
            _conn.Execute("DELETE FROM Sales WHERE SalesID = @id;", new { id = sales.SalesID });
        }
    }
}

