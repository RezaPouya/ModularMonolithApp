using Framework.Core.Exceptions;

namespace Account.Domains.User.Exceptions
{
    public sealed class UserAccountValidationException : UserValidationException
    {
        public UserAccountValidationException(string message) : base(message)
        {
        }
    }
}