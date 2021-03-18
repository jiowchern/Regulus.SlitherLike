using Regulus.SlitherLike.Logic.Common;

namespace Regulus.SlitherLike.Logic.Main
{
    public interface IMapNode : IEntity, Collection.IQuadObject
    {
        new Utility.Vector2 Position { get; }

        void SetRotation(long frames, float rot);
        void Advance(long frames);
        
    }
}