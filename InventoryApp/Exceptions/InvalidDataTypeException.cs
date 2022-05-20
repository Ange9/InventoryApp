using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApp.Exceptions
{

    [Serializable]
    public class InvalidDataTypeException : Exception
    {
        public InvalidDataTypeException() { }

        public InvalidDataTypeException(string message)
            : base(message) { }

        public InvalidDataTypeException(string message, Exception inner)
            : base(message, inner) { }
    }
}