using jim.common.Exceptions;
using System;

namespace jim.models.Entity.Common
{
    public abstract class GenericEntity
    {
        public string Id { get; set; }

        protected GenericEntity()
        {
            Id = Guid.NewGuid().ToString();
        }

        protected GenericEntity(string id)
        {
            Id = id;

        }

        protected string NameOfEntity { get { return this.GetType().Name; } }

        protected Type TypeOfEntity { get { return this.GetType(); } }

        public virtual void Validate()
        {
            if (String.IsNullOrWhiteSpace(Id))
            {
                var msg = jim.common.Errors.Validation.TheIdentifierIsEmpty(this.GetType().Name);
                throw new ValidationCustomException(this.GetType(), nameof(Id), msg);
            }
        }


        public override bool Equals(object obj)
        {

            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            if (!((GenericEntity)obj).Id.Equals(Id))
            {
                return false;
            }

            return true;

        }

    }
}
