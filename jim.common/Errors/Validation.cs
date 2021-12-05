using System;

namespace jim.common.Errors
{
    public static class Validation
    {
        /// <summary>
        /// Get a validation message about id empty
        /// </summary>
        /// <param name="entityName">name of entity</param>
        /// <returns>string message error</returns>
        public static string TheIdentifierIsEmpty(string entityName)
        {
            return String.Format(Languages.Error.ResourceManager.GetString("EMPTY_IDENTIFIER"), entityName);
        }

        public static string ThePropertyIsNullOrEmpty(string propertyName, string entityName)
        {

            return String.Format(Languages.Error.ResourceManager.GetString("PROPERTY_NULL_OR_EMPTY"), propertyName, entityName);
        }



    }
}
