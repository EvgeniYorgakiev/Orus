using System;

namespace Orus.Exceptions
{
    class InvalidName : Exception
    {
        public InvalidName(string message)
             : base(message)
        {

        }
    }
}
