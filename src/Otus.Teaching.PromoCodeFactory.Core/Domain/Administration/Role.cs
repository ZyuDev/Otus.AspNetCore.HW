using System;

namespace Otus.Teaching.PromoCodeFactory.Core.Domain.Administration
{
    public class Role
        : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public override void Update(BaseEntity source)
        {

            if (source is Role sourceRole)
            {
                Name = sourceRole.Name;
                Description = sourceRole.Description;
            }

        }
    }
}