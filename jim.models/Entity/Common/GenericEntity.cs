using jim.common.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace jim.models.Entity.Common
{
    public abstract class GenericEntity
    {
        public string Id { get;  set; }

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
    
    }
}
