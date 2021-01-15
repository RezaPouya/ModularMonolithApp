namespace Account.Domains.Common.Contracts
{
    public interface IDomainEvent
    {
        public string AggregateId { get; }
        public long Id { get; }

        public bool IsSavedInPresistenceMedia { get; }
    }
}