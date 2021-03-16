using Regulus.Remote;
using Regulus.Remote.Reactive;
using Regulus.SlitherLike.Logic.Common;
using Regulus.Utility;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Collections.Generic;


namespace Regulus.SlitherLike.Logic.Main
{
    
    class UserLogin : Regulus.Utility.IStatus , Common.ILogin
    {
        private readonly ICollection<ILogin> _Logins;
        readonly IWorld _World;
        readonly System.Reactive.Disposables.CompositeDisposable _Disposables;

        public event System.Action<IPlayer> DoneEvent;
        public UserLogin(ICollection<ILogin> items , IWorld world)
        {
            _World = world;
            this._Logins = items;
            _Disposables = new System.Reactive.Disposables.CompositeDisposable();
        }

        void IStatus.Enter()
        {
            _Logins.Add(this);
        }

        void IStatus.Leave()
        {
            _Logins.Remove(this);
            _Disposables.Clear();
        }

        Value<bool> ILogin.Login(string name)
        {

            var obs = from id in _World.Create(name).RemoteValue()
                      select id;
            _Disposables.Add(obs.Subscribe(DoneEvent));            
            return true;
        }

        void IStatus.Update()
        {
            
        }
    }
}
