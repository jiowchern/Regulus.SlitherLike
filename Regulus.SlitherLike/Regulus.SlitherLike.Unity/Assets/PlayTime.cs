using UnityEngine;
using UniRx;
using System;

namespace Regulus.SlitherLike.Unity
{
    public class PlayTime : MonoBehaviour
    {
        long _Frames;

        readonly UniRx.CompositeDisposable _Disposables;

        float _DeltaTime;
        public static long Frames { get {
                return GameObject.FindObjectOfType<PlayTime>()._Frames;
            } }

        public PlayTime()
        {
            _Disposables = new UniRx.CompositeDisposable();
        }

        public void Start()
        {

            var resetFramesObs = from play in NotifierRx.ToObservable().Supply<Logic.Common.IPlay>()
                              from frames in play.Frames.ObserveEveryValueChanged(p => p.Value)
                              select frames;
            resetFramesObs.Subscribe(_Reset).AddTo(_Disposables);
        }

        private void _Reset(long frames)
        {
            _Frames = frames;
        }

        private void OnDestroy()
        {
            _Disposables.Clear();
        }

        private void Update()
        {
            _DeltaTime += UnityEngine.Time.deltaTime;
            var secondPerFrames = Regulus.SlitherLike.Logic.Common.Configs.SecondPerFrames;
            var deltaFrames = (long)(_DeltaTime * secondPerFrames);
            if (deltaFrames < 1)
            {
                return;
            }
            _DeltaTime = 0;
            _Frames += deltaFrames;
        }
    }

}
