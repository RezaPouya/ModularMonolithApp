﻿using Framework.Core.Attributes;
using Framework.Core.Common.Contracts;
using Framework.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Framework.Core.Common.Behaviours
{
    public static class DomainEventInfoRegisterationHelper
    {
        public static List<DomainEventInfo> RegisterDomainEvents(List<Assembly> assemblies)
        {
            var types = _getDomainEvents(assemblies);
            return _getRegisterationModelList(types);
        }

        private static List<Type> _getDomainEvents(IList<Assembly> assemblies)
        {
            List<Type> list = new List<Type>();

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes()
                    .Where(t => t.IsPublic && t.BaseType == typeof(DomainEvent))
                    .ToList();

                list.AddRange(types);
            }

            return list;
        }

        private static List<DomainEventInfo> _getRegisterationModelList(List<Type> types)
        {
            List<DomainEventInfo> _registerationList = new List<DomainEventInfo>();

            foreach (var type in types)
            {
                var attrList = type.GetCustomAttributes(typeof(DomainEventInfoAttribute), true);

                _ensureEventHasDomainEventInfoAttribut(type, attrList);
                
                _ensureEventHasOnlyOneDomainEventInfoAttribut(type, attrList);
                
                DomainEventInfoAttribute domainEventInfo = attrList.FirstOrDefault() as DomainEventInfoAttribute;

                _ensureEventIsNotDuplicated(type, domainEventInfo, _registerationList);

                _registerationList.Add(_generateRegisterationModel(type, domainEventInfo));
            }

            return _registerationList;
        }

        private static DomainEventInfo _generateRegisterationModel(Type type, DomainEventInfoAttribute domainEventInfo)
        {
            return new DomainEventInfo
            {
                Aggregate = domainEventInfo.Aggregate,
                CurrentType = type,
                DeleteEvent = domainEventInfo.DeleteEvent,
                Name = domainEventInfo.Name,
                SnapShot = domainEventInfo.SnapShot,
                SystemGenerated = domainEventInfo.SystemGenerated,
                UniqueTypeId = domainEventInfo.UniqueTypeId,
                Version = domainEventInfo.Version
            };
        }

        private static void _ensureEventHasOnlyOneDomainEventInfoAttribut(Type type, object[] attrList)
        {
            if (attrList.Count() >= 2)
                throw new Exception($"Event {nameof(type)} has more than 1 DomainEventInfoAttribute !!");
        }

        private static void _ensureEventHasDomainEventInfoAttribut(Type type, object[] attrList)
        {
            if (attrList.Count() <= 0)
                throw new Exception($"Event {nameof(type)} doesn't have any DomainEventInfoAttribute !!");
        }

        private static void _ensureEventIsNotDuplicated(Type @type, DomainEventInfoAttribute domainEventInfo, List<DomainEventInfo> registerdEvents)
        {
            var uniqueIdIsDuplicated = registerdEvents.FirstOrDefault(p => p.UniqueTypeId == domainEventInfo.UniqueTypeId);

            if (uniqueIdIsDuplicated != null && uniqueIdIsDuplicated.Version == domainEventInfo.Version)
            {
                throw new Exception($"Type of {@type} and {uniqueIdIsDuplicated.CurrentType} has same uniqueTypeId with same version");
            }
        }
    }
}