using System;

namespace Regulus.SlitherLike.Logic.Main
{
    class Time : ITime
    {
        
        readonly Regulus.Utility.TimeCounter _TimeCounter;
        long _Frames;
        public Time()
        {
            _TimeCounter = new Regulus.Utility.TimeCounter();
            _Frames = 0;
        }
        long ITime.Frames => _Frames;


        internal bool Advance()
        {
            var frames = _TimeCounter.Second * Regulus.SlitherLike.Logic.Common.Configs.SecondPerFrames;            
            if (frames < Regulus.SlitherLike.Logic.Common.Configs.StepPerFrames)
                return false;
            _TimeCounter.Reset();
            _Frames += Regulus.SlitherLike.Logic.Common.Configs.StepPerFrames;
            return true;
        }
    }
}