using System;

namespace Domain.Contract
{
    public abstract class Entity : IEntity<string>
    {
        public string Id { get; set; }
        public Entity()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
    public interface IEntity<TId> 
    {
        public TId Id { get; set; }
    }
}
