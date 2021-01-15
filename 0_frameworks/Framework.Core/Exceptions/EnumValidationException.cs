using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Exceptions
{
    public sealed class EnumValidationException : Exception
    {
        public EnumValidationException(string message) : base(message)
        {
        }
    }
}
