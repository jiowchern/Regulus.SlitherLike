using Regulus.SlitherLike.Logic.Common;
using Regulus.Utility;
using System;
using System.Collections.Generic;

namespace Regulus.SlitherLike.Logic.Main
{
    class Map : IMap
    {
        readonly Regulus.Collection.QuadTree<IMapNode> _QuadTree;
        readonly System.Collections.Generic.List<IMapNode> _Nodes;
        public Map()
        {
            _Nodes = new List<IMapNode>();
            _QuadTree = new Collection.QuadTree<IMapNode>(new Size(1, 1), int.MaxValue);
        }

        void IMap.Join(IMapNode entity)
        {
            _QuadTree.Insert(entity);
            _Nodes.Add(entity);
        }

        void IMap.Leave(IMapNode entity)
        {
            _Nodes.Remove(entity);
            _QuadTree.Remove(entity);
        }

        IEnumerable<IMapNode> IMap.Query(Rect rect)
        {
            var controllers = _QuadTree.Query(rect);
            foreach (var contorller in controllers)
            {
                yield return contorller;
            }
        }

        internal void Update(ITime time)
        {
            foreach (var node in _Nodes)
            {
                node.Advance(time.Frames);
            }
            
        }
    }
}