using Regulus.SlitherLike.Logic.Common;
using Regulus.Utility;
using System.Collections.Generic;

using System.Reactive.Linq;
using Regulus.Remote.Reactive;
using System;

namespace Regulus.SlitherLike.Logic.Main
{
    internal class UserPlay : Regulus.Utility.IStatus , Common.IPlay
    {
        private readonly long _Id;
        private readonly ICollection<IPlay> _Plays;
        private readonly ICollection<IEntity> _Entities;
        private readonly ICollection<IEntityController> _Controllers;
        private readonly IPlayer _Zone;
        readonly System.Reactive.Disposables.CompositeDisposable _Disposables;

        public event System.Action DoneEvent;
        public UserPlay(
            IPlayer zone,
            ICollection<IEntity> entities, 
            ICollection<IEntityController> controllers,
            ICollection<IPlay> plays
            )
        {
            _Id = zone.Main.Value;
            _Plays = plays;
            _Zone = zone;            
            _Entities = entities; 
            _Controllers = controllers;            
            _Disposables = new System.Reactive.Disposables.CompositeDisposable();
        }

        void IStatus.Enter()
        {
            _Plays.Add(this);
            _SetupEntiry();
            _SetupController();

        }

        private void _SetupEntiry()
        {
            _Entities.Clear();

            var addControllerObs = from entity in _Zone.Entities.SupplyEvent()                                   
                                   select entity;

            _Disposables.Add(addControllerObs.Subscribe(s=>_Entities.Add(s)));

            var removeControllerObs = from entity in _Zone.Entities.UnsupplyEvent()                                      
                                      select entity;

            _Disposables.Add(removeControllerObs.Subscribe(s => _Entities.Remove(s)));
        }
        
        private void _SetupController()
        {
            _Controllers.Clear();

            var addControllerObs = from entity in _Zone.Entities.SupplyEvent()
                                   where entity.Id.Value == _Id
                                   select entity;

            _Disposables.Add(addControllerObs.Subscribe(_Controllers.Add));

            var removeControllerObs = from entity in _Zone.Entities.UnsupplyEvent()
                                      where entity.Id.Value == _Id
                                      select entity;

            _Disposables.Add(removeControllerObs.Subscribe(s => _Controllers.Remove(s)));
        }


        void IStatus.Leave()
        {
            _Disposables.Clear();
            _Plays.Remove(this);
            _Zone.Exit();
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