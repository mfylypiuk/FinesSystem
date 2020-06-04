using FinesSystem.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinesSystem.Repositories
{
    public class CarsRepository
    {
        SQLiteConnection database;

        public CarsRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Car>();
        }

        public int DeleteItem(int id)
        {
            return database.Delete<Car>(id);
        }

        public Car GetItem(int id)
        {
            return database.Get<Car>(id);
        }

        public IEnumerable<Car> GetItems()
        {
            return database.Table<Car>().ToList();
        }

        public int SaveItem(Car item)
        {
            if (item.Id != 0)
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
