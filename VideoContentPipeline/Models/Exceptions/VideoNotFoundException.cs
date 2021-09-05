using System;
using System.Runtime.Serialization;

namespace VideoContentPipeline.Models.Exceptions
{   
    public class VideoNotFoundException : Exception
    {
        public VideoNotFoundException() { }
        public VideoNotFoundException(string message) : base(message) { }
        public VideoNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected VideoNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}