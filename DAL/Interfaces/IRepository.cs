using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    /// <summary>
    /// IRepository pattern for encapsulating the logic of working with data sources.
    /// </summary>
    /// <typeparam name="T">parameter of model.</typeparam>
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
