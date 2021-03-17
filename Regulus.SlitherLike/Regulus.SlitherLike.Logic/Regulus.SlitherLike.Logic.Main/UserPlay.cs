using Regulus.SlitherLike.Logic.Common;
using Regulus.Utility;
using System.Collections.Generic;

using System.Reactive.Linq;
using Regulus.Remote.Reactive;
using System;
using Regulus.Remote;

namespace Regulus.SlitherLike.Logic.Main
{
    internal class UserPlay : Regulus.Utility.IStatus , Common.IPlay
    {
        private readonly long _Id;
        private readonly ICollection<IPlay> _Plays;        
        private readonly ICollection<IPlayer> _Players;
        private readonly IPlayer _Player;
        readonly IWorld _World;
        readonly System.Reactive.Disposables.CompositeDisposable _Disposables;

        Property<long> IPlay.Frames => _World.Frames;

        public event System.Action DoneEvent;
        public UserPlay(
            IPlayer player,            
            ICollection<IPlayer> players,
            ICollection<IPlay> plays,
            IWorld world
            )
        {
            _World = world;
            _Player = player;
            _Plays = plays;                     
            _Players = players;            
            _Disposables = new System.Reactive.Disposables.CompositeDisposable();
        }

        void IStatus.Enter()
        {
            _Plays.Add(this);
            _Players.Add(_Player);
        }

        
        
        


        void IStatus.Leave()
        {
            _Disposables.Clear();
            _Players.Remove(_Player);
            _Plays.Remove(this);
            _Player.Exit();
        }

        void IStatus.Update()
        {
            
        }

        void IPlay.Exit()
        {
            
            DoneEvent();
        }
    }
}