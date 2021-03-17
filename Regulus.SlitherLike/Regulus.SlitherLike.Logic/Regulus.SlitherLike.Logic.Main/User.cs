using Regulus.Remote;
using Regulus.SlitherLike.Logic.Common;
using Regulus.Utility;
using System;

namespace Regulus.SlitherLike.Logic.Main
{
    public class User : Regulus.Utility.IUpdatable  , Common.IUser
    {
        readonly private IBinder _Binder;
        readonly Regulus.Utility.StatusMachine _Machine;
        bool _Enable;
        private IWorld _World;
        readonly NotifiableCollection<ILogin> _Logins;
        Remote.Notifier<ILogin> IUser.Logins => new Remote.Notifier<ILogin>(_Logins);


        


        readonly NotifiableCollection<IPlayer> _Players;
        Remote.Notifier<IPlayer> IUser.Players => new Remote.Notifier<IPlayer>(_Players);

        readonly NotifiableCollection<IPlay> _Plays;
        Remote.Notifier<IPlay> IUser.Plays => new Remote.Notifier<IPlay>(_Plays);

        public User(IBinder binder,IWorld world)
        {
            _World = world;
            _Plays = new NotifiableCollection<IPlay>();
            _Players = new NotifiableCollection<IPlayer>();
            
            _Logins = new NotifiableCollection<ILogin>();
            _Enable = true;
            binder.BreakEvent += () => _Enable = false;
            this._Binder = binder;
            _Machine = new StatusMachine();
        }

        void IBootable.Launch()
        {
            _Binder.Bind<Common.IUser>(this);
            _ToLogin();
        }

        private void _ToLogin()
        {
            
            var status = new UserLogin(_Logins.Items,_World);            
            status.DoneEvent += _ToPlay;            
            _Machine.Push(status);
        }

        private void _ToPlay(IPlayer player)
        {
            var status = new UserPlay(player, _Players.Items, _Plays.Items, _World);
            status.DoneEvent += _ToLogin;
            _Machine.Push(status);
        }

        void IBootable.Shutdown()
        {
            _Binder.Unbind<Common.IUser>(this);
            _Machine.Termination();
        }

        bool IUpdatable.Update()
        {
            _Machine.Update();
            return _Enable;
        }
    }
}
