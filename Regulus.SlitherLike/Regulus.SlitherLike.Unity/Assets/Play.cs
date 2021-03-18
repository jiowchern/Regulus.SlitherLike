using Regulus.SlitherLike.Logic.Common;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using System.Linq;
using UnityEngine;
namespace Regulus.SlitherLike.Unity
{
    public class Play : MonoBehaviour
    {
        public GameObject EntityPrefab;
        readonly System.Collections.Generic.List<Entity> _Entities;
        readonly UniRx.CompositeDisposable _Disposables;

        public Play()
        {
            _Entities = new List<Entity>();
            _Disposables = new UniRx.CompositeDisposable();
        }
        // Start is called before the first frame update
        void Start()
        {
            var addEntityObs = from player in NotifierRx.ToObservable().Supply<Logic.Common.IPlayer>()
                                from entity in player.Entities.SupplyEvent()
                                select new { Self = entity.Owner.Value == player.Id.Value, Entity = entity };

            addEntityObs.Subscribe(v => _AddEntity(v.Self, v.Entity)).AddTo(_Disposables);

            var removeEntityObs = from player in NotifierRx.ToObservable().Supply<Logic.Common.IPlayer>()
                               from entity in player.Entities.UnsupplyEvent()
                               select new { Self = entity.Owner.Value == player.Id.Value, Entity = entity };

            removeEntityObs.Subscribe(v => _RemoveEntity(v.Self, v.Entity)).AddTo(_Disposables);
        }

        private void _RemoveEntity(bool self, IEntity entity)
        {
            var es = from e in _Entities
                    where e.Id == entity.Id
                    select e;
            foreach (var item in es)
            {
                GameObject.Destroy(item.gameObject);
            }
            foreach (var item in es.ToArray())
            {
                _Entities.Remove(item);
            }
        }

        private void _AddEntity(bool self, IEntity entity)
        {
            var entityObj = GameObject.Instantiate<GameObject>(EntityPrefab);

            var entityCom = entityObj.GetComponent<Entity>();
            entityCom.Setup(entity);
            _Entities.Add(entityCom);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnDestroy()
        {
            _Disposables.Clear();
        }
    }

}
