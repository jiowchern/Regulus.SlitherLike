using Regulus.Remote;
using Regulus.SlitherLike.Logic.Common;
using System;
using System.Collections.Generic;

namespace Regulus.SlitherLike.Logic.Main
{
    internal class Player : IPlayer , Regulus.Utility.IUpdatable
    {
        readonly IEntityController _Main;
        private readonly IVision _Vision;
        bool _Enable;

        public Player(IEntityController main, IVision vision)
        {
            _Main = main;
            _Vision = vision;
            _Entities = new NotifiableCollection<IEntityController>();
            _DifferenceNotifier = new Collection.DifferenceNotifier<IEntityController>();
        }


        Property<long> IPlayer.Main => new Property<long>(_Main.Id);

        readonly Regulus.Remote.NotifiableCollection<IEntityController> _Entities;
        Notifier<IEntityController> IPlayer.Entities => new Notifier<IEntityController>(_Entities);

        readonly Collection.DifferenceNotifier<IEntityController> _DifferenceNotifier;
        void IPlayer.Exit()
        {
            _Enable = false;
        }

        bool Utility.IUpdatable.Update()
        {
            var rect = new Regulus.Utility.Rect(new Regulus.Utility.Point(_Main.Position.Value.X, _Main.Position.Value.Y), new Regulus.Utility.Size(10, 10));
            var entitys = _Vision.Query(rect);
            _DifferenceNotifier.Set(entitys);
            return _Enable;
        }

        void Utility.IBootable.Launch()
        {
            _Enable = true;
            _DifferenceNotifier.JoinEvent += _Join;
            _DifferenceNotifier.LeaveEvent+= _Leave;
        }

        void Utility.IBootable.Shutdown()
        {
            
            _DifferenceNotifier.Set(new IEntityController[0]);
            _DifferenceNotifier.JoinEvent -= _Join;
            _DifferenceNotifier.LeaveEvent -= _Leave;
            _Entities.Items.Clear();
            _Enable = false;
        }

        private void _Leave(IEnumerable<IEntityController> instances)
        {
            foreach (var instance in instances)
            {
                _Entities.Items.Remove(instance);
            }
        }

        private void _Join(IEnumerable<IEntityController> instances)
        {
            foreach (var instance in instances)
            {
                _Entities.Items.Add(instance);
            }
        }

        
    }
}