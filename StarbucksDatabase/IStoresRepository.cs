using System;
using System.Collections.Generic;
using StarbucksDatabase.Models;

namespace StarbucksDatabase
{
    public interface IStoresRepository
    {
        public IEnumerable<Stores> GetAllStores();
        public Stores GetStores(int id);
        public void UpdateStores(Stores stores);
        public void InsertStores(Stores StoresTOInsert);
        public void DeleteStores(Stores stores);

    }
}
