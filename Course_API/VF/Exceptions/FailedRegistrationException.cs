﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_API.Exceptions
{
    public class FailedRegistrationException : Exception
    {
        public FailedRegistrationException(string message) : base(message) { }
    }
}
