using Regulus.Remote.Client.Tcp;
using System.Linq;
using UnityEngine;
using UniRx;
using System.Net.Sockets;
using System;

namespace Regulus.SlitherLike.Unity
{
    public class UIOnline : MonoBehaviour
    {
        public UnityEngine.UI.Button Close;
        public UIConnect Connect;
        readonly UniRx.CompositeDisposable _Disposables;
        
        public UIOnline()
        {
            
            _Disposables = new CompositeDisposable();
        }
        private void Start()
        {
                        
        }
        private void OnDestroy()
        {
            _Disposables.Clear();
        }
        internal void Setup(IOnlineable online)
        {
            gameObject.SetActive(true);
            _Disposables.Clear();
            var errorObs = from result in UniRx.Observable.FromEvent<System.Net.Sockets.SocketError>((h) => online.ErrorEvent += h, (h) => online.ErrorEvent -= h)
                            select result;
            errorObs.Subscribe(_Result).AddTo(_Disposables);

            var closeObs = from _ in Close.OnClickAsObservable()
                           select _;
            closeObs.Subscribe(_ => { online.Disconnect(); }).AddTo(_Disposables);


        }

        

        private void _Result(SocketError error)
        {
            gameObject.SetActive(false);
            Connect.Show(error);
        }
    }


}
