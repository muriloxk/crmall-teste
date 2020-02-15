using System;

namespace Crmall.Domain.Entities
{
    public class Entity : IEquatable<Entity>
    {
        public Entity() 
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }

        public bool Equals(Entity Outro)
        {
            return Id == Outro.Id;
        }
    }
}
