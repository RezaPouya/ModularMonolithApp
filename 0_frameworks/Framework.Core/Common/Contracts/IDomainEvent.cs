namespace Framework.Core.Common.Contracts
{
    public interface IDomainEvent
    {
        public string AggregateId { get; }
        public long Id { get; }
        public bool SavedInPersistenceMedia { get; }
    }
}