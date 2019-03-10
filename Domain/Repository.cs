using System;

namespace Domain
{
    public abstract class Repository<T> where T : AggregateRoot
    {
        public T GetById(long id)
        {

        }

        public void Save(T aggregateRoot)
        {
            
        }

    }
}
