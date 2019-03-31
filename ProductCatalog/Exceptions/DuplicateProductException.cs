using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProductCatalog.Exceptions
{
    public class DuplicateProductException : BaseCustomException
    {
        public DuplicateProductException(string message, string description): base(message, description, (int)HttpStatusCode.BadRequest)
        {

        }
    }
}
