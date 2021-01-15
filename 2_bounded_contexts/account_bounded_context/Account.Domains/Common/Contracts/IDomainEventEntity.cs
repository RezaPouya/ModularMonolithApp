namespace Account.Domains.Common.Contracts
{
    public interface IDomainEventEntity<T> : IEntity where T : struct
    {
        public long EventId { get; set; }
        public string DomainId { get; set; }
        public long CreateDateTime { get; set; }
        public string CreatorUser { get; set; }
        public string Ip { get; set; }
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public bool Deleted { get; set; }
        public bool DeleteEvent { get; set; }
        public bool SubscribedEvent { get; set; }
        public bool SystemEvent { get; set; }
        public bool Published { get; set; }
        public long PublishDateTime { get; set; }
    }
}