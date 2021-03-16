using Regulus.Remote;
using Regulus.SlitherLike.Logic.Common;
using System;

namespace Regulus.SlitherLike.Logic.Main
{ 
    
    public class Entry : Regulus.Remote.IEntry , System.IDisposable
    {
    
        readonly Regulus.Utility.Updater _Users;
        readonly Regulus.Remote.ThreadUpdater _Runner;
        private readonly IWorld _World;

        public Entry()
        {
            _World = new World();
            _Users = new Utility.Updater();
            _Runner = new ThreadUpdater(_Update);
            _Runner.Start();
        }

        private void _Update()
        {
            _Users.Working();
        }

        void IBinderProvider.AssignBinder(IBinder binder, object state)
        {
            _Users.Add(new User(binder, _World));
        }

        void IDisposable.Dispose()
        {
            _Runner.Stop();
        }
    }
}
