using System;
using System.Collections.Generic;
using System.Text;

namespace jim.common.Exceptions
{
    public class CustomNotFoundException:CustomException 
    {
        public string EntityName { get; private set; }
        public Type EntityType { get; private set; }
        public string FindedId { get; private set; }
        /// <summary>
        /// Exception throwed if not found a entity
        /// </summary>
        /// <param name="type">Type of entity not found</param>
        /// <param name="id">findend identifier</param>
        public CustomNotFoundException(Type type,string id):base(Errors.Common.NotFoundEntityWithId(type.Name, id))
        {
            EntityName = nameof(type);
            EntityType = type;
            FindedId = id;
        }
    }
}
