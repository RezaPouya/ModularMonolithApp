namespace Account.Domains.Common.Contracts
{
    public abstract record DomainDeleteEvent : DomainEvent
    {
        protected DomainDeleteEvent(string aggregateId) : base(aggregateId)
        {
        }

        public bool IsDeleteEvent => true;
    }
}