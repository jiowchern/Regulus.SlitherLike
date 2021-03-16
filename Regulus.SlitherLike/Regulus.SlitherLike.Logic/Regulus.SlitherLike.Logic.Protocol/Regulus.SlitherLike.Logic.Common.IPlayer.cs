   
    using System;  
    
    using System.Collections.Generic;
    
    namespace Regulus.SlitherLike.Logic.Common.Ghost 
    { 
        public class CIPlayer : Regulus.SlitherLike.Logic.Common.IPlayer , Regulus.Remote.IGhost
        {
            readonly bool _HaveReturn ;
            
            readonly long _GhostIdName;
            
            
            
            public CIPlayer(long id, bool have_return )
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
            
            
                void Regulus.SlitherLike.Logic.Common.IPlayer.Exit()
                {                    

                    Regulus.Remote.IValue returnValue = null;
                    var info = typeof(Regulus.SlitherLike.Logic.Common.IPlayer).GetMethod("Exit");
                    _CallMethodEvent(info , new object[] {} , returnValue);                    
                    
                }

                


                    public Regulus.Remote.Property<System.Int64> _Main= new Regulus.Remote.Property<System.Int64>();
                    Regulus.Remote.Property<System.Int64> Regulus.SlitherLike.Logic.Common.IPlayer.Main { get{ return _Main;} }

                    public Regulus.Remote.Notifier<Regulus.SlitherLike.Logic.Common.IEntityController> _Entities= new Regulus.Remote.Notifier<Regulus.SlitherLike.Logic.Common.IEntityController>();
                    Regulus.Remote.Notifier<Regulus.SlitherLike.Logic.Common.IEntityController> Regulus.SlitherLike.Logic.Common.IPlayer.Entities { get{ return _Entities;} }

            
        }
    }
