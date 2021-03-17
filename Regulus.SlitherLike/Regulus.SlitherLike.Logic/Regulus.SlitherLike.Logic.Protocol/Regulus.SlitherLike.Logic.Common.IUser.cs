   
    using System;  
    
    using System.Collections.Generic;
    
    namespace Regulus.SlitherLike.Logic.Common.Ghost 
    { 
        public class CIUser : Regulus.SlitherLike.Logic.Common.IUser , Regulus.Remote.IGhost
        {
            readonly bool _HaveReturn ;
            
            readonly long _GhostIdName;
            
            
            
            public CIUser(long id, bool have_return )
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
            
            

                    public Regulus.Remote.Notifier<Regulus.SlitherLike.Logic.Common.ILogin> _Logins= new Regulus.Remote.Notifier<Regulus.SlitherLike.Logic.Common.ILogin>();
                    Regulus.Remote.Notifier<Regulus.SlitherLike.Logic.Common.ILogin> Regulus.SlitherLike.Logic.Common.IUser.Logins { get{ return _Logins;} }

                    public Regulus.Remote.Notifier<Regulus.SlitherLike.Logic.Common.IPlay> _Plays= new Regulus.Remote.Notifier<Regulus.SlitherLike.Logic.Common.IPlay>();
                    Regulus.Remote.Notifier<Regulus.SlitherLike.Logic.Common.IPlay> Regulus.SlitherLike.Logic.Common.IUser.Plays { get{ return _Plays;} }

                    public Regulus.Remote.Notifier<Regulus.SlitherLike.Logic.Common.IPlayer> _Players= new Regulus.Remote.Notifier<Regulus.SlitherLike.Logic.Common.IPlayer>();
                    Regulus.Remote.Notifier<Regulus.SlitherLike.Logic.Common.IPlayer> Regulus.SlitherLike.Logic.Common.IUser.Players { get{ return _Players;} }

            
        }
    }
