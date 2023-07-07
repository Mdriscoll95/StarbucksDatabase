using System;
using System.Collections.Generic;
using StarbucksDatabase.Models;
using System.Data;
using Dapper;

namespace StarbucksDatabase
{
    public class StoresRepository : IStoresRepository

    {
        private readonly IDbConnection _conn;

        public StoresRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Stores> GetAllStores()
        {
            return _conn.Query<Stores>("SELECT * FROM Stores;");
        }
        public Stores GetStores(int id)
        {
            return _conn.QuerySingle<Stores>("SELECT * FROM Stores WHERE StoreID = @id", new { id = id });
        }
        public void UpdateStores(Stores stores)
        {
            _conn.Execute("UPDATE Stores SET Location = @location, Manager = @manager, NumberOfEmployees = @numberOfEmployees WHERE StoreID = @id",
             new { location = stores.Location, manager = stores.Manager, numberOfEmployees = stores.NumberOfEmployees, id = stores.StoreID});
        }
        public void InsertStores(Stores StoresToStores)
        {
            _conn.Execute("INSERT INTO Stores (Location, Manager, NumberOfEmployees) VALUES (@location, @manager, numberOfEmployees);",
                new { location = StoresToStores.Location, manager = StoresToStores.Manager, numberOfEmployees = StoresToStores.NumberOfEmployees });


        }
        public void DeleteStores(Stores stores)
        {
            _conn.Execute("DELETE FROM Stores WHERE StoreID = @id;", new { id = stores.StoreID });

        }

        
    }
}


