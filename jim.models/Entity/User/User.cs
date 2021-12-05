using jim.common.Errors;
using jim.common.Exceptions;
using jim.models.Entity.Common;
using System;

namespace jim.models.Entity.Users
{
    public class User : GenericEntity
    {

        public string Name { get; private set; }


        private User()
        {

        }

        public static User Create(string name, string id)
        {
            var user = new User();
            user.Name = name;
            user.Id = id;
            user.Validate();
            return user;
        }

        public override void Validate()
        {
            base.Validate();
            if (String.IsNullOrWhiteSpace(Name))
            {
                var msg = Validation.ThePropertyIsNullOrEmpty(nameof(Name), this.NameOfEntity);
                throw new ValidationCustomException(this.GetType(), nameof(Name), msg);
            }


        }

       

    }
}
