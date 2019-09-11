using System;
using System.Runtime.Serialization;

namespace MarsRover
{
    public class BlockingObjectException : Exception
    {
        public BlockingObjectException()
        {
        }

        public BlockingObjectException(string message) : base(message)
        {
        }

        public BlockingObjectException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BlockingObjectException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
