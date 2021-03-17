using System;

namespace Regulus.SlitherLike.Logic.Common
{
    [Regulus.Remote.Attributes.SyntaxHelper]
    public interface IEntity
    {
        Regulus.Remote.Property<long> Id { get; }

        Regulus.Remote.Property<long> Owner { get; } 
        Regulus.Remote.Property<long> Frames { get; }
        Regulus.Remote.Property<Utility.Vector2> Position { get; }        
        Regulus.Remote.Property<float> Speed { get; }
        Regulus.Remote.Property<float> Rotation { get; }
        
    }
}
