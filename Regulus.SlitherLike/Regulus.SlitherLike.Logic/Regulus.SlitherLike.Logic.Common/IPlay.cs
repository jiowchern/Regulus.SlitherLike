namespace Regulus.SlitherLike.Logic.Common
{
    [Regulus.Remote.Attributes.SyntaxHelper]
    public interface IPlay
    {
        Regulus.Remote.Property<long> Frames { get; }
        void Exit();
    }
}
