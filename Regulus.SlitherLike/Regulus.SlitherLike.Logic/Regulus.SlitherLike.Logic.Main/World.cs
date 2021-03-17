using Regulus.Remote;
using Regulus.SlitherLike.Logic.Common;
using Regulus.Utility;
using System;

namespace Regulus.SlitherLike.Logic.Main
{
    internal class World : IWorld , Regulus.Utility.IUpdatable  
    {
        readonly Time _Time;
        readonly Regulus.Utility.Updater _Players;
        readonly Map _Map;

        int _UpdateFramesCount;
        readonly Property<long>  _Frames;
        Property<long> IWorld.Frames => _Frames;

        public World()
        {
            _Time = new Time();
            _Map = new Map();
            _Players = new Utility.Updater();
            _Frames = new Property<long>();
        }

        Value<IPlayer> IWorld.Create(string name)
        {
            var player = new Player(name , _Map, _Time);
            
            _Players.Add(player);
            
            return player;
        }
        

        bool IUpdatable.Update()
        {
            if(!_Time.Advance())
            {
                return true;
            }
            
            _Players.Working();
            _Map.Update(_Time);
            _UpdateFrames(_Time);
            return true;
        }

        private void _UpdateFrames(ITime time)
        {
            
            if(_UpdateFramesCount == 0)
            {
                _Frames.Value = time.Frames;
                _UpdateFramesCount = 10;
            }
            else
            {
                _UpdateFramesCount--;
            }
        }

        void IBootable.Launch()
        {
            
        }

        void IBootable.Shutdown()
        {
            _Players.Shutdown();

        }
    }
}