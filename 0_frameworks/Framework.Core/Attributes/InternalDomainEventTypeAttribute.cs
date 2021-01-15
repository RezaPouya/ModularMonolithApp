using System;

namespace Framework.Core.Attributes
{
    public class InternalDomainEventTypeAttribute : Attribute
    {
        public InternalDomainEventTypeAttribute(string bounded_Countext, string domain, string id)
        {
            Bounded_Countext = bounded_Countext;
            Domain = domain;
            Id = id;
        }

        public string Bounded_Countext { get; set; }
        public string Domain { get; set; }
        public string Id { get; set; }
        public string UniqueId => $"{Bounded_Countext}-{Domain}-{Id}";
    }
}