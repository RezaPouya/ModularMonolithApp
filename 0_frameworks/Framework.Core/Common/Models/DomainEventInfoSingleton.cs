using Framework.Core.Common.Behaviours;
using Framework.Core.Common.Contracts;
using Framework.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Framework.Core.Common.Models
{
    public class DomainEventInfoSingleton
    {
        // to make it thread safe
        private static readonly Lazy<DomainEventInfoSingleton> _instance =
            new Lazy<DomainEventInfoSingleton>(() => new DomainEventInfoSingleton());

        // private constructor
        private DomainEventInfoSingleton()
        {
            _domainEvents = DomainEventInfoRegisterationHelper.RegisterDomainEvents(DomainEventInfoSingleton._assemblies);
        }

        public static DomainEventInfoSingleton GetInstance(List<Assembly> assemblies)
        {
            _assemblies = assemblies;
            return _instance.Value;
        }

        public static DomainEventInfoSingleton GetInstance()
        {
            return _instance.Value;
        }

        #region behaviour

        protected static List<Assembly> _assemblies { get; private set; }
        protected List<DomainEventInfo> _domainEvents { get; private set; }

        public IDomainEvent GetDomainInstance(DomainEventEntity domainEventEntity)
        {
            var registredEventModel = _domainEvents.FirstOrDefault(p => p.UniqueTypeId == domainEventEntity.UniqueTypeId);

            if (registredEventModel == null)
                throw new System.Exception($"There is no Registerd Event with Unique Id of '{domainEventEntity.UniqueTypeId}'");

            var obj = JsonSerializerHelper.DesSerialize(domainEventEntity.Data, registredEventModel.CurrentType);

            return obj as IDomainEvent;
        }

        #endregion behaviour
    }
}