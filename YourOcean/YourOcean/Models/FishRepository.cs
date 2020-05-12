using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using YourOcean.Models;

namespace YourOcean
{
    public class FishRepository
    {
        SQLiteConnection database;
        public FishRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Fish>();
        }
        public IEnumerable<Fish> GetItems()
        {
            return database.Table<Fish>().ToList();
        }
        public Fish GetItem(int id)
        {
            return database.Get<Fish>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Fish>(id);  
        }
        public int SaveItem(Fish item)
        {
            if(item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
