using System;
using System.Collections.Generic;
using System.Text;

namespace jim.common.Exceptions
{
    public class ValidationCustomException : CustomException
    {
        public string PropertyName { get; private set; }
        public Type EntityType { get; private set; }

        /// <summary>
        /// Exception throwed if not found a entity
        /// </summary>
        /// <param name="entityName">Type of entity not found</param>
        /// <param name="id">findend identifier</param>
        public ValidationCustomException(Type type, string propertyName, string msg) : base(msg)
        {
            PropertyName = propertyName;
            EntityType = type;
        }
    }
}
