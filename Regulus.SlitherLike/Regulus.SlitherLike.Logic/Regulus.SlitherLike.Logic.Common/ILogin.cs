namespace Regulus.SlitherLike.Logic.Common
{
    public static class Configs
    {
        public static int SecondPerFrames = 30;
        public static int StepPerFrames = 3;        
    }
    [Regulus.Remote.Attributes.SyntaxHelper]
    public interface ILogin
    {
        Regulus.Remote.Value<bool> Login(string name);

    }
}
