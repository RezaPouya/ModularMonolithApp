namespace Framework.Core.Common.Contracts
{
    public interface IDomainDeleteEvent : IDomainEvent
    {
        public bool IsDeleteEvent => true;
    }
}