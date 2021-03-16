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


        readonly NotifiableCollection<IEntity> _Entities;
        Remote.Notifier<IEntity> IUser.Entities => new Remote.Notifier<IEntity>(_Entities);


        readonly NotifiableCollection<IEntityController> _Controllers;
        Remote.Notifier<IEntityController> IUser.Controllers => new Remote.Notifier<IEntityController>(_Controllers);

        readonly NotifiableCollection<IPlay> _Plays;
        Remote.Notifier<IPlay> IUser.Plays => new Remote.Notifier<IPlay>(_Plays);

        public User(IBinder binder,IWorld world)
        {
            _World = world;
            _Plays = new NotifiableCollection<IPlay>();
            _Controllers = new NotifiableCollection<IEntityController>();
            _Entities = new NotifiableCollection<IEntity>();
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

        private void _ToPlay(IPlayer zone)
        {
            var status = new UserPlay(zone , _Entities.Items , _Controllers.Items, _Plays.Items );
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
