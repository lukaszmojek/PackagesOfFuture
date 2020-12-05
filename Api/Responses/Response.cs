using System;

namespace WebApplication.Responses
{
    public abstract class Response
    {
        public bool Succeeded { get; set; }
        public Exception Exception { get; set; }
    }
}