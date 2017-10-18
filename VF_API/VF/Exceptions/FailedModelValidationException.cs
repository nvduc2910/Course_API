using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_API.Exceptions
{
    public class FailedModelValidationException : Exception
    {
        public FailedModelValidationException(string message) : base(message)
        {

        }
    }
}
