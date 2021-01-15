using System;

namespace Framework.Core.Exceptions
{
    public abstract class AggregateValidationException : Exception
    {
        public AggregateValidationException(string message) : base(message) 
        {
        }
    }
}