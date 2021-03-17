namespace Regulus.SlitherLike.Logic.Common
{
    [Regulus.Remote.Attributes.SyntaxHelper]
    public interface IWorld
    {        
        Regulus.Remote.Value<IPlayer> Create(string name);
        Regulus.Remote.Property<long> Frames { get; }
    }
}
