using Regulus.Collection;
using Regulus.Remote;
using Regulus.SlitherLike.Logic.Common;
using Regulus.Utility;
using System;

namespace Regulus.SlitherLike.Logic.Main
{
    class Entity : IMapNode
    {
        static readonly IdProvider _IdProvider = new IdProvider();
        public readonly long Id;
        public readonly long Owner;
        readonly Property<float> _Rotation;
        readonly Property<long> _Frames;
        readonly Property<Vector2> _StartPosition;
        
        Rect _Bounds;
        private readonly float _Speed;

        public Entity(long owner)
        {
            Owner = owner;
            this.Id = _IdProvider.Provider.Rent();
            _Rotation = new Property<float>();
            _Frames = new Property<long>();
            _Bounds = new Rect(0,0,1,1);
            _StartPosition = new Property<Vector2>();            
            _StartPosition.Value = _Bounds.Center.ToVector2();
            _Speed = 1;
        }
        ~Entity()
        {
            _IdProvider.Provider.Return(this.Id);
        }
        

        Rect IQuadObject.Bounds => _Bounds;

        Property<long> IEntity.Id => new Property<long>(Id);

        Property<long> IEntity.Frames => _Frames;

        Property<Vector2> IEntity.Position => _StartPosition;

        Property<float> IEntity.Speed => new Property<float>(_Speed);

        Property<float> IEntity.Rotation => _Rotation;

        Property<long> IEntity.Owner => new Property<long>(Owner);

        Vector2 IMapNode.Position => _Bounds.Center.ToVector2();

        event System.Action<IQuadObject> _BoundsChanged;
        event System.Action<IQuadObject> IQuadObject.BoundsChanged
        {
            add
            {
                _BoundsChanged += value;
            }

            remove
            {
                _BoundsChanged -= value;
            }
        }

        void IMapNode.Advance(long frames)
        {

            var deltaFrames = frames - _Frames.Value;
            var deltaSecond = deltaFrames / (float)Regulus.SlitherLike.Logic.Common.Configs.SecondPerFrames;
            Vector2 velocity = _ToVector(_Rotation.Value) * _Speed * deltaSecond;
            var position = _Bounds.Center.ToVector2();
            var nextPosition = position + velocity;
            _Bounds = new Rect(new Point(nextPosition.X + _Bounds.Width/2, nextPosition.Y + _Bounds.Height/2) , new Size(1,1));
            if(_BoundsChanged != null)
                _BoundsChanged(this);
        }

        private Vector2 _ToVector(float rotation)
        {
            var radians = rotation * 0.0174532924;
            return new Vector2((float)Math.Cos(radians), (float)-Math.Sin(radians));
        }

        void IMapNode.SetRotation(long frames, float rotation)
        {
            _Frames.Value = frames;
            _StartPosition.Value = _Bounds.Center.ToVector2();
            _Rotation.Value = rotation;
        }
    }
}