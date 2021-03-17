using Regulus.SlitherLike.Logic.Common;
using Regulus.Utility;

namespace Regulus.SlitherLike.Logic.Main
{
    public interface IMap
    {
        void Join(IMapNode entity);
        void Leave(IMapNode entity);

        System.Collections.Generic.IEnumerable<IMapNode> Query(Rect rect);
    }
}