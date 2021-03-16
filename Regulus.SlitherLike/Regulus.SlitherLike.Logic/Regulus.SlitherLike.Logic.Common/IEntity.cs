﻿using System;

namespace Regulus.SlitherLike.Logic.Common
{
    [Regulus.Remote.Attributes.SyntaxHelper]
    public interface IEntity
    {
        Regulus.Remote.Property<long> Id { get; }
        Regulus.Remote.Property<long> Tick { get; }
        Regulus.Remote.Property<Utility.Vector2> Position { get; }        
        Regulus.Remote.Property<Utility.Vector2> Direction { get; }
        Regulus.Remote.Property<Utility.Vector2> Rotation { get; }

    }
}
