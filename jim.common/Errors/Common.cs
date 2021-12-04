using System;
using System.Collections.Generic;
using System.Text;

namespace jim.common.Errors
{
    public class Common
    {

        /// <summary>
        /// text used for uncontrolled errors, generate trace by request 
        /// </summary>
        /// <param name="entityName">name of entity</param>
        /// <param name="id">finded identifier</param>
        /// <returns></returns>
        public static string GenericError()
        {
            var traceErrorId = Guid.NewGuid().ToString();
            return String.Format(Languages.Error.ResourceManager.GetString("GENERIC_ERROR"), traceErrorId);
        }

        /// <summary>
        /// Get a message related of entity not found with id
        /// </summary>
        /// <param name="entityName">name of entity</param>
        /// <param name="id">finded identifier</param>
        /// <returns></returns>
        public static string NotFoundEntityWithId(string entityName, string id)
        {
            return String.Format(Languages.Error.ResourceManager.GetString("NOT_FOUND_ENTITY"), entityName,id);
        }

    }
}
