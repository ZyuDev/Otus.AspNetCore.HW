using System;

namespace Otus.Teaching.PromoCodeFactory.Core.Domain
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public abstract void Update(BaseEntity source);
    }
}