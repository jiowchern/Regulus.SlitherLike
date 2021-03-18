using Regulus.Remote.Client.Tcp;
using System.Linq;
using UnityEngine;
using UniRx;

namespace Regulus.SlitherLike.Unity
{
}
namespace Regulus.SlitherLike.Unity
{
    public class Client : MonoBehaviour
    {
        public static Client Instance { get {
                return GameObject.FindObjectOfType<Client>();
            } }
        readonly Regulus.Remote.Ghost.IAgent _Agent;
        public readonly Connecter Connecter;
        public readonly Remote.INotifierQueryable Queryable;

        public Client()
        {
            var type = Regulus.Remote.Protocol.ProtocolProvider.GetProtocols().Single();
            Regulus.Remote.IProtocol protocol = System.Activator.CreateInstance(type) as Regulus.Remote.IProtocol;
            Regulus.Remote.Ghost.IAgent agent = Regulus.Remote.Client.Provider.CreateAgent(protocol);
            _Agent = agent;
            Queryable = _Agent;
            Connecter = Regulus.Remote.Client.Provider.CreateTcp(_Agent);

        }
        public void Update()
        {
            _Agent.Update();
        }
        
    }


}
