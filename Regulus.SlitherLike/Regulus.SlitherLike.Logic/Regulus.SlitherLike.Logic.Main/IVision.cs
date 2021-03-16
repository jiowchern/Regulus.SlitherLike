using Regulus.SlitherLike.Logic.Common;
using Regulus.Utility;

namespace Regulus.SlitherLike.Logic.Main
{
    public interface IVision
    {
        System.Collections.Generic.IEnumerable<IEntityController> Query(Rect rect);
    }
}