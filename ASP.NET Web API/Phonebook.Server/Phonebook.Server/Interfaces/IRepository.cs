using System.Collections.Generic;

namespace Phonebook.Server.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Add(T t, string text);
        T Edit(T t);
        T Delete(int id);
        IEnumerable<T> Filter(string text);
        IEnumerable<T> Sort(string direction);
    }
}