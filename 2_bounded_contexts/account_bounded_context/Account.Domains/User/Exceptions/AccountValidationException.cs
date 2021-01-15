using Framework.Core.Exceptions;

namespace Account.Domains.User.Exceptions
{
    public class UserValidationException : AggregateValidationException
    {
        public UserValidationException(string message) : base(message)
        {
        }
    }
}