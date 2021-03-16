namespace Regulus.SlitherLike.Logic.Common
{
    [Regulus.Remote.Attributes.SyntaxHelper]
    public interface ILogin
    {
        Regulus.Remote.Value<bool> Login(string name);

    }
}
