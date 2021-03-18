using UnityEngine;
using UniRx;
using System;
using System.Collections;

namespace Regulus.SlitherLike.Unity
{
    public static class NotifierRx
    {

        public static IObservable<Regulus.Remote.INotifierQueryable> ToObservable()
        {
            return UniRx.Observable.FromCoroutine<Regulus.Remote.INotifierQueryable>(_RunWaitAgent);
        }
        private static IEnumerator _RunWaitAgent(IObserver<Regulus.Remote.INotifierQueryable> observer)
        {

            while (Client.Instance == null)
            {
                yield return new WaitForEndOfFrame();
            }
            while (Client.Instance.Queryable == null)
            {
                yield return new WaitForEndOfFrame();
            }
            observer.OnNext(Client.Instance.Queryable);
            observer.OnCompleted();
        }

        

        public static IObservable<TGpi> Supply<TGpi>(this IObservable<Regulus.Remote.INotifierQueryable> observable)
        {
            return observable.ContinueWith(_Supply<TGpi>);
        }

        private static IObservable<TGpi> _Supply<TGpi>(Regulus.Remote.INotifierQueryable agent)
        {
            return Observable.FromEvent<Action<TGpi>, TGpi>(h => (gpi) => h(gpi), h => agent.QueryNotifier<TGpi>().Supply += h, h => agent.QueryNotifier<TGpi>().Supply -= h);
        }

        public static IObservable<TGpi> Unsupply<TGpi>(this IObservable<Regulus.Remote.INotifierQueryable> observable)
        {
            return observable.ContinueWith<Regulus.Remote.INotifierQueryable, TGpi>(_Unsupply<TGpi>);
        }

        private static IObservable<TGpi> _Unsupply<TGpi>(Regulus.Remote.INotifierQueryable agent)
        {
            return Observable.FromEvent<System.Action<TGpi>, TGpi>(h => (gpi) => h(gpi), h => agent.QueryNotifier<TGpi>().Unsupply += h, h => agent.QueryNotifier<TGpi>().Unsupply -= h);
        }


    }
}
