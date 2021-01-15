namespace Account.Domains.Common.Contracts
{
    public interface IDomainDeleteEvent : IDomainEvent
    {
        public bool IsDeleteEvent => true;
    }
}