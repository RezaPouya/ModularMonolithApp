namespace Framework.Core.Common.Contracts
{
    public interface IDomainEvent
    {
        public string AggregateId { get;  }
        public long Id { get;  }
        public bool SavedInPersistenceMedia { get;  }
        public string UniqueTypeId { get; }
        public ushort Version { get; }
        public bool SystemGenerated { get; }
        public bool DeleteEvent { get; }
        public bool SnapShot { get; }
        public ushort SnapShotCount { get;  }

        public string UserId { get; }

        public string Ip { get; }
        public void SetSavedInPersistenceMedia();
    }
}