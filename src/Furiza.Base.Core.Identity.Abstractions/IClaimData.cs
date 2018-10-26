﻿using System;

namespace Furiza.Base.Core.Identity.Abstractions
{
    public interface IClaimData
    {
        string Type { get; }
        string Value { get; }
        DateTime? CreationDate { get; }
        string CreationUser { get; }
    }
}