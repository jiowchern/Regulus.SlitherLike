using Regulus.Collection;
using Regulus.Remote;
using Regulus.SlitherLike.Logic.Common;
using Regulus.Utility;
using System;

namespace Regulus.SlitherLike.Logic.Main
{
    class Entity : IMapNode
    {
        public readonly long Id;

        public Entity(long id)
        {
            this.Id = id;
        }
        Property<long> IEntity.Id => new Property<long>(Id);

        Property<long> IEntity.Tick => throw new NotImplementedException();

        Property<Vector2> IEntity.Position => throw new NotImplementedException();

        Property<Vector2> IEntity.Direction => throw new NotImplementedException();

        Property<Vector2> IEntity.Rotation => throw new NotImplementedException();

        Rect IQuadObject.Bounds => throw new NotImplementedException();

        event EventHandler IQuadObject.BoundsChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        void IEntityController.SetDirection()
        {
            throw new NotImplementedException();
        }
    }
}