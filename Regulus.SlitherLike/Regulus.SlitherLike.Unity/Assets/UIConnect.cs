using Regulus.Remote.Client.Tcp;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using System.Net.Sockets;

namespace Regulus.SlitherLike.Unity
{
    public class UIConnect : MonoBehaviour
    {
        public Client Client;
        public UIOnline Online;
        public UnityEngine.UI.Text Address;
        public UnityEngine.UI.Text Port;
        public UnityEngine.UI.Text Message;
        public UnityEngine.UI.Button Connect;

        readonly UniRx.CompositeDisposable _Disposables;
        readonly UniRx.CompositeDisposable _ButtonDisposables;
        public UIConnect()
        {
            _ButtonDisposables = new CompositeDisposable();
            _Disposables = new CompositeDisposable();
        }

        private void OnDestroy()
        {
            _ButtonDisposables.Clear();
            _Disposables.Clear();
        }
        private void Start()
        {
            var connectObs = from _ in Connect.OnClickAsObservable()
                        select _;
            connectObs.Subscribe(_ => OnConnect()).AddTo(_ButtonDisposables);
        }
        public void OnConnect()
        {
            _Disposables.Clear();
            var address = System.Net.IPAddress.Parse(Address.text);
            var endpoint = new System.Net.IPEndPoint(address, int.Parse(Port.text));
            var connectObs = from conline in Client.Connecter.Connect(endpoint).ToObservable().ObserveOnMainThread()
                            select conline;

            connectObs.Subscribe(_Result).AddTo(_Disposables);
        }

        private void _Result(IOnlineable online)
        {
            if(online != null)
            {
                Message.text = "connect success.";
                Online.Setup(online);
                gameObject.SetActive(false);
            }
            else
            {
                Message.text = "connect fail.";
            }
        }

        internal void Show(SocketError error)
        {
            gameObject.SetActive(true);
            Message.text = $"connect fail.{error}";
        }
    }


}
