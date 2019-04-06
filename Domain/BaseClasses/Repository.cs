using System;

namespace Domain
{
    public abstract class Repository<T> where T : AggregateRoot
    {
        public abstract T GetById(long id);

        public abstract void Save(T aggregateRoot);

    }
}
