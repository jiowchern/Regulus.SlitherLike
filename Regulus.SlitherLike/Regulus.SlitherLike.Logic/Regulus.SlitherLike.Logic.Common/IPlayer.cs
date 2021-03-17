namespace Regulus.SlitherLike.Logic.Common
{
    [Regulus.Remote.Attributes.SyntaxHelper]
    public interface IPlayer
    {
        Regulus.Remote.Property<long> Id { get; }
        Regulus.Remote.Property<string> Name { get; }
        Regulus.Remote.Notifier<IEntity> Entities { get; }

        void Exit();

        void SetDirection(DIRECTION dir);
    }
}
