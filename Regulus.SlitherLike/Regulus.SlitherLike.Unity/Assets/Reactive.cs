using System;
using UniRx;

namespace Regulus.SlitherLike.Unity
{
    public static class Reactive
    {
        public static IObservable<T> FromActionPattern<T>(Action<Action<T>> addHandler, Action<Action<T>> removeHandler)
        {
            return Observable.FromEvent<System.Action<T>, T>(h => (gpi) => h(gpi), addHandler, removeHandler);
        }
    }
}
