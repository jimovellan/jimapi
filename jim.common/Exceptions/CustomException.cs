using System;
using System.Collections.Generic;
using System.Text;

namespace jim.common.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string msg):base(msg)
        {
            
        }
    }
}
