using Domain.Entities.BaseClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories.BaseClasses
{
    public abstract class CrudRepository<T> where T : Value<T>
    {
        public abstract Task Add(T obj);

        public abstract Task<List<T>> Get();

        public abstract void Remove(T obj);

        public abstract Task Save();
    }
}