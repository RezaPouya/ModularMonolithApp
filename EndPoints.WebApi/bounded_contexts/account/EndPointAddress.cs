using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoints.WebApi.bounded_contexts.account
{
    public abstract class EndPointAddress
    {
        public const string _controller = "api/Account";

        public const string Profile = nameof(Profile);
        public const string SignUp = nameof(SignUp);

    }
}
