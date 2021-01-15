using Account.Domains.Common.ValidationsMessages;
using Framework.Core.Exceptions;
using System;

namespace Account.Domains.Common.Behaviours
{
    public static class ValueObjectValidator
    {
        public static void Validate<TException>(this ValidationModel model) where TException : AggregateValidationException
        {
            if (model == null)
                throw new Exception("validation model is empty");

            if (model.IsValid == false)
                return;

            throw (TException)Activator.CreateInstance(typeof(TException), model.GetValidationErrorMessages());
        }
    }
}