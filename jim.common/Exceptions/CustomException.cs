using System;

namespace jim.common.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string msg) : base(msg)
        {

        }
    }
}
