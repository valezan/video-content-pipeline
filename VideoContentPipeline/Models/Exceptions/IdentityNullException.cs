using System;
using System.Runtime.Serialization;

namespace VideoContentPipeline.Models.Exceptions
{   
    public class IdentityNullException : Exception
    {
        public IdentityNullException() { }
        public IdentityNullException(string message) : base(message) { }
        public IdentityNullException(string message, Exception inner) : base(message, inner) { }
        protected IdentityNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}