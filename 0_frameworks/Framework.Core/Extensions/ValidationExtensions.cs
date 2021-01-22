using Framework.Core.Common.Models;
using Framework.Core.Exceptions;
using System;

namespace Framework.Core.Extensions
{
    public static class ValidationExtensions
    {
        public static void IsNotNotOrEmpty<TException>(this string str, string errorMessage) where TException : AggregateValidationException
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                throw (TException)Activator.CreateInstance(typeof(TException), errorMessage);
        }

        public static void IsDateTimeIsFromNowOn<TException>(this DateTimeOffset dateTime, string errorMessage) where TException : AggregateValidationException
        {
            if (dateTime == default || dateTime < DateTimeOffset.UtcNow )
                throw (TException)Activator.CreateInstance(typeof(TException), errorMessage);
        }
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