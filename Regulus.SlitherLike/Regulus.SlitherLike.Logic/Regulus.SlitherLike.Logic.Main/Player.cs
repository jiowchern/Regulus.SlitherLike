using Regulus.Remote;
using Regulus.SlitherLike.Logic.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Regulus.SlitherLike.Logic.Main
{
    internal class Player : IPlayer , Regulus.Utility.IUpdatable
    {
        const float TurnLeft = 500f;
        const float TurnRight = -500f;
        const float TurnStop = 0f;        
        

        readonly static IdProvider _IdProvider = new IdProvider();
        long _Id;
        readonly string _Name;
        private readonly IMap _Map;
        bool _Enable;        
        DIRECTION? _Direction;
        readonly ITime _Time;
        public Player(string name,IMap map,ITime time)
        {
            _Time = time;
            _Id = _IdProvider.Provider.Rent();
            _Name = name;
            _Map = map;
            _Entities = new NotifiableCollection<IEntity>();
            _Owns = new NotifiableCollection<IMapNode>();
            _DifferenceNotifier = new Collection.DifferenceNotifier<IEntity>();
        }
        ~Player()
        {
            _IdProvider.Provider.Return(_Id);
        }

        readonly Regulus.Remote.NotifiableCollection<IEntity> _Entities;
        Notifier<IEntity> IPlayer.Entities => new Notifier<IEntity>(_Entities);

        readonly Regulus.Remote.NotifiableCollection<IMapNode> _Owns;        

        
        Property<string> IPlayer.Name => new Property<string>(_Name);

        Property<long> IPlayer.Id => new Property<long>(_Id);

        readonly Collection.DifferenceNotifier<IEntity> _DifferenceNotifier;
        void IPlayer.Exit()
        {
            _Enable = false;
        }

        bool Utility.IUpdatable.Update()
        {
            var head = _Owns.Items.First();
            if(_Direction == DIRECTION.LEFT)
                head.SetRotation(_Time.Frames , TurnLeft);
            else if (_Direction == DIRECTION.RIGHT)
                head.SetRotation(_Time.Frames,TurnRight);
            else if (_Direction == DIRECTION.NONE)
                head.SetRotation(_Time.Frames,TurnStop);
            _Direction = null;

            var rect = new Regulus.Utility.Rect(new Regulus.Utility.Point(head.Position.X, head.Position.Y), new Regulus.Utility.Size(10, 10));
            var entitys = _Map.Query(rect);
            _DifferenceNotifier.Set(entitys);
            return _Enable;
        }

        void Utility.IBootable.Launch()
        {
            _Enable = true;


            var entity = new Entity(_Id);
            _Owns.Items.Add(entity);
            _Map.Join(entity);


            _DifferenceNotifier.JoinEvent += _Join;
            _DifferenceNotifier.LeaveEvent+= _Leave;
        }

        void Utility.IBootable.Shutdown()
        {
            _Map.Leave(_Owns.First());
            _Owns.Items.Clear();
            _DifferenceNotifier.Set(new IEntity[0]);
            _DifferenceNotifier.JoinEvent -= _Join;
            _DifferenceNotifier.LeaveEvent -= _Leave;
            _Entities.Items.Clear();
            _Enable = false;
        }

        private void _Leave(IEnumerable<IEntity> instances)
        {
            foreach (var instance in instances)
            {
                _Entities.Items.Remove(instance);
            }
        }

        private void _Join(IEnumerable<IEntity> instances)
        {
            foreach (var instance in instances)
            {
                _Entities.Items.Add(instance);
            }
        }

        void IPlayer.SetDirection(DIRECTION dir)
        {
            _Direction = dir;
        }
    }
}