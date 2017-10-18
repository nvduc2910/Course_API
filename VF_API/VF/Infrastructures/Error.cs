using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_API.Infrastructures
{
    public class Error
    {
        public dynamic errorMessage { get; set; }
        public int errorCode { get; set; }
    }
}
