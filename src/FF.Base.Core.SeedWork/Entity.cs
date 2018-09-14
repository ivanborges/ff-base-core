﻿using System;
using System.Data.SqlTypes;

namespace FF.Base.Core.SeedWork
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public DateTime CreationDate { get; protected set; } = SqlDateTime.MinValue.Value;
        public string CreationUser { get; set; }

        public bool IsTransient() => Id == default(Guid);

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            var item = (Entity)obj;
            if (item.IsTransient() || IsTransient())
                return false;
            else
                return item.Id == Id;
        }

        int? _requestedHashCode;
        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = Id.GetHashCode() ^ 31;

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
                return (Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right) => !(left == right);
    }
}