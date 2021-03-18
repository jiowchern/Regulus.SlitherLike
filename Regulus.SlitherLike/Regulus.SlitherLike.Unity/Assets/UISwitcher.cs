using UnityEngine;
using UniRx;
using Regulus.SlitherLike.Logic.Common;

namespace Regulus.SlitherLike.Unity
{
    public class UISwitcher : MonoBehaviour
    {
        public UILogin Login;
        readonly UniRx.CompositeDisposable _Disposables;
        public UISwitcher()
        {
            _Disposables = new CompositeDisposable();
        }
        private void Start()
        {
            NotifierRx.ToObservable().Supply<ILogin>().Subscribe(Login.Show).AddTo(_Disposables);
            NotifierRx.ToObservable().Unsupply<ILogin>().Subscribe(Login.Hide).AddTo(_Disposables);

        }
        private void OnDestroy()
        {
            _Disposables.Clear();
        }
    }


}
