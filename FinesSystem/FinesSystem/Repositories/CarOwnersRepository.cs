using FinesSystem.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinesSystem.Repositories
{
    public class CarOwnersRepository : IRepository<CarOwner>
    {
        SQLiteConnection database;

        public CarOwnersRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<CarOwner>();
        }

        public int DeleteItem(int id)
        {
            return database.Delete<CarOwner>(id);
        }

        public CarOwner GetItem(int id)
        {
            return database.Get<CarOwner>(id);
        }

        public IEnumerable<CarOwner> GetItems()
        {
            return database.Table<CarOwner>().ToList();
        }

        public int SaveItem(CarOwner item)
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
