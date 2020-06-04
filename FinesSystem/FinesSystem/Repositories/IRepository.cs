using System;
using System.Collections.Generic;
using System.Text;

namespace FinesSystem.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetItems();
        T GetItem(int id);
        int DeleteItem(int id);
        int SaveItem(T item);
    }
}
