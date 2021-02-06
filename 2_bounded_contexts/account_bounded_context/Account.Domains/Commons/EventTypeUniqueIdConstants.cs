namespace Account.Domains.Commons
{
    public abstract class EventTypeUniqueIdConstants
    {
        public abstract class UserAggregate
        {
            public const string AGGREGATE_NAME = "User";
            public const string USER_CREATED_EVENT = "6e6c62fb-cd5e-4a0a-b78c-043ba3a4f974";
            public const string USER_NAME_IS_CHANGED = "a295fac3-aa21-4a8c-88d1-bb5112f509de";
            public const string USER_CONFIRMATION_CODE_IS_CREATED = "28e4bbda-8ff8-477e-a8b9-56058f9d48df";
        }
    }
}