using Regulus.Remote;
using Regulus.SlitherLike.Logic.Common;
using Regulus.Utility;
using System.Collections.Generic;

namespace Regulus.SlitherLike.Logic.Main
{
    internal class World : IWorld , IVision , ILandlordProviable<long> 
    {
        long _Ids;
        readonly Regulus.Remote.Landlord<long> _IdProvider;
        readonly Regulus.Utility.Updater _Players;
        readonly Regulus.Collection.QuadTree<IMapNode> _QuadTree;
        public World()
        {
            _IdProvider = new Landlord<long>(this);
            _QuadTree = new Collection.QuadTree<IMapNode>(new Size(1,1) , 1000);
            _Players = new Utility.Updater();
        }

        Value<IPlayer> IWorld.Create(string name)
        {

            var entiry = new Entity(_IdProvider.Rent());

            _QuadTree.Insert(entiry);

            var player = new Player(entiry, this);
            
            _Players.Add(player);
            // todo 開始處理移動相關邏輯
            return player;
        }

        IEnumerable<IEntityController> IVision.Query(Rect rect)
        {
            var controllers = _QuadTree.Query(rect);
            foreach (var contorller in controllers)
            {
                yield return contorller;
            }
        }

        long ILandlordProviable<long>.Spawn()
        {
            return ++_Ids;
        }
    }
}