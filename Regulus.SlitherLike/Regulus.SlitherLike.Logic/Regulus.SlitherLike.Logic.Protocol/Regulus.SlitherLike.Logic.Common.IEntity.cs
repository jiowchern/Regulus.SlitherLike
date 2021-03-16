   
    using System;  
    
    using System.Collections.Generic;
    
    namespace Regulus.SlitherLike.Logic.Common.Ghost 
    { 
        public class CIEntity : Regulus.SlitherLike.Logic.Common.IEntity , Regulus.Remote.IGhost
        {
            readonly bool _HaveReturn ;
            
            readonly long _GhostIdName;
            
            
            
            public CIEntity(long id, bool have_return )
            {                                
                _HaveReturn = have_return ;
                _GhostIdName = id; 
                
            }
            

            long Regulus.Remote.IGhost.GetID()
            {
                return _GhostIdName;
            }

            bool Regulus.Remote.IGhost.IsReturnType()
            {
                return _HaveReturn;
            }
            object Regulus.Remote.IGhost.GetInstance()
            {
                return this;
            }

            private event Regulus.Remote.CallMethodCallback _CallMethodEvent;

            event Regulus.Remote.CallMethodCallback Regulus.Remote.IGhost.CallMethodEvent
            {
                add { this._CallMethodEvent += value; }
                remove { this._CallMethodEvent -= value; }
            }

            private event Regulus.Remote.EventNotifyCallback _AddEventEvent;

            event Regulus.Remote.EventNotifyCallback Regulus.Remote.IGhost.AddEventEvent
            {
                add { this._AddEventEvent += value; }
                remove { this._AddEventEvent -= value; }
            }

            private event Regulus.Remote.EventNotifyCallback _RemoveEventEvent;

            event Regulus.Remote.EventNotifyCallback Regulus.Remote.IGhost.RemoveEventEvent
            {
                add { this._RemoveEventEvent += value; }
                remove { this._RemoveEventEvent -= value; }
            }
            
            

                    public Regulus.Remote.Property<System.Int64> _Id= new Regulus.Remote.Property<System.Int64>();
                    Regulus.Remote.Property<System.Int64> Regulus.SlitherLike.Logic.Common.IEntity.Id { get{ return _Id;} }

                    public Regulus.Remote.Property<System.Int64> _Tick= new Regulus.Remote.Property<System.Int64>();
                    Regulus.Remote.Property<System.Int64> Regulus.SlitherLike.Logic.Common.IEntity.Tick { get{ return _Tick;} }

                    public Regulus.Remote.Property<Regulus.Utility.Vector2> _Position= new Regulus.Remote.Property<Regulus.Utility.Vector2>();
                    Regulus.Remote.Property<Regulus.Utility.Vector2> Regulus.SlitherLike.Logic.Common.IEntity.Position { get{ return _Position;} }

                    public Regulus.Remote.Property<Regulus.Utility.Vector2> _Direction= new Regulus.Remote.Property<Regulus.Utility.Vector2>();
                    Regulus.Remote.Property<Regulus.Utility.Vector2> Regulus.SlitherLike.Logic.Common.IEntity.Direction { get{ return _Direction;} }

                    public Regulus.Remote.Property<Regulus.Utility.Vector2> _Rotation= new Regulus.Remote.Property<Regulus.Utility.Vector2>();
                    Regulus.Remote.Property<Regulus.Utility.Vector2> Regulus.SlitherLike.Logic.Common.IEntity.Rotation { get{ return _Rotation;} }

            
        }
    }
