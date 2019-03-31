using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Exceptions
{
    public class BaseCustomException : Exception
    {
        public int Code { get; private set; }
        public string Description { get; private set; }

        public BaseCustomException(string message, string description, int code): base(message)
        {
            Code = code;
            Description = description;
        }
    }
}
