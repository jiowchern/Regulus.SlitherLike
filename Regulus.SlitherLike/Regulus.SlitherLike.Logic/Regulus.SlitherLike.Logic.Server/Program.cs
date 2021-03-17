using System;
using System.Linq;
using Regulus.Utility.WindowConsoleAppliction;

namespace Regulus.SlitherLike.Logic.Server
{

    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="port"></param>
        static void Main(int port)
        {
            var entry = new Regulus.SlitherLike.Logic.Main.Entry();
            IDisposable dispose = entry;
            var assembly = System.Reflection.Assembly.LoadFrom("Regulus.SlitherLike.Logic.Protocol.dll");
            var protocol = Regulus.Remote.Protocol.ProtocolProvider.Create(assembly);
            var service = Regulus.Remote.Server.Provider.CreateService(entry, protocol);
            var listener = Regulus.Remote.Server.Provider.CreateTcp(service);
            listener.Bind(port);
            var console = new Console();
            console.Run();
            listener.Close();
            dispose.Dispose();
        }
    }
}
