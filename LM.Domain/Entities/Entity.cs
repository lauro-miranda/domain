using System;
using LM.Domain.Helpers;

namespace LM.Domain.Entities
{
    public abstract class Entity
    {
        protected const string ConstructorObsoleteMessage = "Created only for EF";

        [Obsolete(ConstructorObsoleteMessage, true)]
        protected Entity() { }
        protected Entity(Guid code)
        {
            Code = code;
        }

        public long Id { get; internal set; }

        public Guid Code { get; protected set; } = Guid.NewGuid();

        public DateTime CreatedAt { get; internal set; } = DateTimeHelper.GetCurrentDate();

        public DateTime LastUpdate { get; internal set; } = DateTimeHelper.GetCurrentDate();

        public DateTime? DeletedAt { get; private set; }

        public bool Deleted => DeletedAt.HasValue;

        public void Delete()
        {
            DeletedAt = DateTimeHelper.GetCurrentDate();
            LastUpdate = DateTimeHelper.GetCurrentDate();
        }

        public void UpdateLastUpdatedDate()
        {
            LastUpdate = DateTimeHelper.GetCurrentDate();
        }
    }
}