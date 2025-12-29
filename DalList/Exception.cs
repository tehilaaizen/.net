using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal class DalIdNotFoundException:Exception
    {
        public DalIdNotFoundException(string? message):base(message) { }
       
        public DalIdNotFoundException(string? message, Exception? innerException):base(message, innerException) { }
    }
    internal class DalIdAlreadyExistsException : Exception
    {
        public DalIdAlreadyExistsException(string? message) : base(message) { }

        public DalIdAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException) { }
        
    }
}
