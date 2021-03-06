﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_API.Exceptions
{
    public class FailedSendEmailException : Exception
    {

        /// <summary>
        /// Failed send email exception constructor
        /// </summary>
        /// <param name="message"></param>
        public FailedSendEmailException(string message) : base(message)
        {

        }
    }
}
