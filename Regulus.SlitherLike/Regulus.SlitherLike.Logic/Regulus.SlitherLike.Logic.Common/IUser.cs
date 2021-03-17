namespace Regulus.SlitherLike.Logic.Common
{
    [Regulus.Remote.Attributes.SyntaxHelper]
    public interface IUser 
    {
        Regulus.Remote.Notifier<ILogin> Logins { get; }

        Regulus.Remote.Notifier<IPlay> Plays { get; }        
        Regulus.Remote.Notifier<IPlayer> Players { get; }
    }
}
