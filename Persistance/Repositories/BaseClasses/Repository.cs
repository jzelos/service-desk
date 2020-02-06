using Orbis.Housing.ServiceDesk.Domain.Entities.BaseClasses;
using System.Threading.Tasks;

namespace Persistance.Repositories.BaseClasses
{
    public abstract class Repository<T> where T : AggregateRoot
    {
        public abstract Task Add(T obj);

        // public abstract Task<T> Get();

        public abstract Task<T> GetById(long id);

        //public abstract void Remove(T obj);

        public abstract Task Save();
    }
}