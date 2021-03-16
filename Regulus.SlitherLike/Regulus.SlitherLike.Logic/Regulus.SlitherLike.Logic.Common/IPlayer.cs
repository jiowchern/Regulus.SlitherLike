namespace Regulus.SlitherLike.Logic.Common
{
    [Regulus.Remote.Attributes.SyntaxHelper]
    public interface IPlayer
    {
        Regulus.Remote.Property<long> Main { get; }
        Regulus.Remote.Notifier<IEntityController> Entities { get; }

        void Exit();
    }
}
