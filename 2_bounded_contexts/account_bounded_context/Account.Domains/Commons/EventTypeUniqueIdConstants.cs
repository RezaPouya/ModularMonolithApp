using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Domains.Commons
{
    public abstract class EventTypeUniqueIdConstants
    {
        public abstract class UserAggregate
        {
            public const string AGGREGATE_NAME = "User"; 
            public const string USER_CREATED_EVENT = "6e6c62fb-cd5e-4a0a-b78c-043ba3a4f974"; 
        }
    }
}
