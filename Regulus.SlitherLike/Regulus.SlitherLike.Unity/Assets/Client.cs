using Regulus.Remote.Client.Tcp;
using System.Linq;
using UnityEngine;
using UniRx;

namespace Regulus.SlitherLike.Unity
{
    public class Client : MonoBehaviour
    {
        readonly Regulus.Remote.Ghost.IAgent _Agent;
        public readonly Connecter Connecter;

        public Client()
        {
            var type = Regulus.Remote.Protocol.ProtocolProvider.GetProtocols().Single();
            Regulus.Remote.IProtocol protocol = System.Activator.CreateInstance(type) as Regulus.Remote.IProtocol;
            Regulus.Remote.Ghost.IAgent agent = Regulus.Remote.Client.Provider.CreateAgent(protocol);
            _Agent = agent;
            Connecter = Regulus.Remote.Client.Provider.CreateTcp(_Agent);

        }
        public void Update()
        {
            _Agent.Update();
        }
        
    }


}
