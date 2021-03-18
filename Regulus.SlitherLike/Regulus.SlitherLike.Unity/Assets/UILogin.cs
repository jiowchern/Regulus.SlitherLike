using System.Linq;
using UnityEngine;
using UniRx;
using Regulus.SlitherLike.Logic.Common;
using System;

namespace Regulus.SlitherLike.Unity
{
    public class UILogin : MonoBehaviour
    {
        public UnityEngine.UI.Text Name;
        public UnityEngine.UI.Button Login;

        readonly UniRx.CompositeDisposable _Disposables;
        readonly UniRx.CompositeDisposable _LoginDisposables;
        public UILogin()
        {
            _LoginDisposables = new CompositeDisposable();
            _Disposables = new CompositeDisposable();
        }
        public void OnDestroy()
        {
            _LoginDisposables.Clear();
            _Disposables.Clear();
        }
        public void Start()
        {
            _Disposables.Clear();
            Login.OnClickAsObservable().Subscribe(_DoLogin).AddTo(_Disposables);

        }

        private void _DoLogin(Unit obj)
        {
            _LoginDisposables.Clear();
            var loginObs = from  login in NotifierRx.ToObservable().Supply<Regulus.SlitherLike.Logic.Common.ILogin>()                           
                            select login;
            loginObs.Subscribe(login => login.Login(Name.text)).AddTo(_LoginDisposables); 
        }

        internal void Show(ILogin obj)
        {
            gameObject.SetActive(true);
        }

        internal void Hide(ILogin obj)
        {
            gameObject.SetActive(false);
        }
    }


}
