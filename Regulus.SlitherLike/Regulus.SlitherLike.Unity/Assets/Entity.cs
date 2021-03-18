using Regulus.Remote;
using Regulus.SlitherLike.Logic.Common;
using System;
using UniRx;
using UnityEngine;
namespace Regulus.SlitherLike.Unity
{
    public class Entity : MonoBehaviour
    {
        
        IEntity _Entity;
        readonly UniRx.CompositeDisposable _Disposables;
        public long Id { get; internal set; }

        
        public Entity()
        {
            _Disposables = new UniRx.CompositeDisposable();
        }
        internal void Setup(IEntity entity)
        {
            Id = entity.Id;
            _Entity = entity;
            _Disposables.Clear();
            
        }
        private void Update()
        {
            if (_Entity == null)
                return;
            long frames = PlayTime.Frames;
            var delta = frames - _Entity.Frames.Value; 
            if(delta <= 0)
            {
                return;
            }

            var deltaFrames = delta;
            var deltaSecond = deltaFrames / (float)Regulus.SlitherLike.Logic.Common.Configs.SecondPerFrames;
            Regulus.Utility.Vector2 velocity = _ToVector(_Entity.Rotation.Value) * _Entity.Speed * deltaSecond;
            var position = _Entity.Position.Value;
            var nextPosition = position + velocity;
            gameObject.transform.position = new Vector3(nextPosition.X , 0 , nextPosition.Y) ;

        }

        private Regulus.Utility.Vector2 _ToVector(float rotation)
        {
            var radians = rotation * 0.0174532924;
            return new Regulus.Utility.Vector2((float)Math.Cos(radians), (float)-Math.Sin(radians));
        }

    }

}
