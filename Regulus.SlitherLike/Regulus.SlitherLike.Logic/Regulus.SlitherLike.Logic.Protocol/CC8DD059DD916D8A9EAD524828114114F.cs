
            using System;  
            using System.Collections.Generic;
            
            
                public class CC8DD059DD916D8A9EAD524828114114F : Regulus.Remote.IProtocol
                {
                    readonly Regulus.Remote.InterfaceProvider _InterfaceProvider;
                    readonly Regulus.Remote.EventProvider _EventProvider;
                    readonly Regulus.Remote.MemberMap _MemberMap;
                    readonly Regulus.Serialization.ISerializer _Serializer;
                    readonly System.Reflection.Assembly _Base;
                    public CC8DD059DD916D8A9EAD524828114114F()
                    {
                        _Base = System.Reflection.Assembly.Load("Regulus.SlitherLike.Logic.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
                        var types = new Dictionary<Type, Type>();
                        types.Add(typeof(Regulus.SlitherLike.Logic.Common.IEntity) , typeof(Regulus.SlitherLike.Logic.Common.Ghost.CIEntity) );
types.Add(typeof(Regulus.SlitherLike.Logic.Common.ILogin) , typeof(Regulus.SlitherLike.Logic.Common.Ghost.CILogin) );
types.Add(typeof(Regulus.SlitherLike.Logic.Common.IPlay) , typeof(Regulus.SlitherLike.Logic.Common.Ghost.CIPlay) );
types.Add(typeof(Regulus.SlitherLike.Logic.Common.IPlayer) , typeof(Regulus.SlitherLike.Logic.Common.Ghost.CIPlayer) );
types.Add(typeof(Regulus.SlitherLike.Logic.Common.IUser) , typeof(Regulus.SlitherLike.Logic.Common.Ghost.CIUser) );
types.Add(typeof(Regulus.SlitherLike.Logic.Common.IWorld) , typeof(Regulus.SlitherLike.Logic.Common.Ghost.CIWorld) );
                        _InterfaceProvider = new Regulus.Remote.InterfaceProvider(types);
                        var eventClosures = new List<Regulus.Remote.IEventProxyCreator>();
                        
                        _EventProvider = new Regulus.Remote.EventProvider(eventClosures);
                        _Serializer = new Regulus.Serialization.Serializer(new Regulus.Serialization.DescriberBuilder(typeof(Regulus.Remote.ClientToServerOpCode),typeof(Regulus.Remote.PackageAddEvent),typeof(Regulus.Remote.PackageCallMethod),typeof(Regulus.Remote.PackageErrorMethod),typeof(Regulus.Remote.PackageInvokeEvent),typeof(Regulus.Remote.PackageLoadSoul),typeof(Regulus.Remote.PackageLoadSoulCompile),typeof(Regulus.Remote.PackagePropertySoul),typeof(Regulus.Remote.PackageProtocolSubmit),typeof(Regulus.Remote.PackageRelease),typeof(Regulus.Remote.PackageRemoveEvent),typeof(Regulus.Remote.PackageReturnValue),typeof(Regulus.Remote.PackageSetProperty),typeof(Regulus.Remote.PackageSetPropertyDone),typeof(Regulus.Remote.PackageUnloadSoul),typeof(Regulus.Remote.RequestPackage),typeof(Regulus.Remote.ResponsePackage),typeof(Regulus.Remote.ServerToClientOpCode),typeof(Regulus.SlitherLike.Logic.Common.DIRECTION),typeof(Regulus.Utility.Point),typeof(Regulus.Utility.Vector2),typeof(System.Boolean),typeof(System.Byte[]),typeof(System.Byte[][]),typeof(System.Char),typeof(System.Char[]),typeof(System.Double),typeof(System.Int32),typeof(System.Int64),typeof(System.Single),typeof(System.String)).Describers);
                        _MemberMap = new Regulus.Remote.MemberMap(new System.Reflection.MethodInfo[] {new Regulus.Utility.Reflection.TypeMethodCatcher((System.Linq.Expressions.Expression<System.Action<Regulus.SlitherLike.Logic.Common.ILogin,System.String>>)((ins,_1) => ins.Login(_1))).Method,new Regulus.Utility.Reflection.TypeMethodCatcher((System.Linq.Expressions.Expression<System.Action<Regulus.SlitherLike.Logic.Common.IPlay>>)((ins) => ins.Exit())).Method,new Regulus.Utility.Reflection.TypeMethodCatcher((System.Linq.Expressions.Expression<System.Action<Regulus.SlitherLike.Logic.Common.IPlayer>>)((ins) => ins.Exit())).Method,new Regulus.Utility.Reflection.TypeMethodCatcher((System.Linq.Expressions.Expression<System.Action<Regulus.SlitherLike.Logic.Common.IPlayer,Regulus.SlitherLike.Logic.Common.DIRECTION>>)((ins,_1) => ins.SetDirection(_1))).Method,new Regulus.Utility.Reflection.TypeMethodCatcher((System.Linq.Expressions.Expression<System.Action<Regulus.SlitherLike.Logic.Common.IWorld,System.String>>)((ins,_1) => ins.Create(_1))).Method} ,new System.Reflection.EventInfo[]{  }, new System.Reflection.PropertyInfo[] {typeof(Regulus.SlitherLike.Logic.Common.IEntity).GetProperty("Id"),typeof(Regulus.SlitherLike.Logic.Common.IEntity).GetProperty("Owner"),typeof(Regulus.SlitherLike.Logic.Common.IEntity).GetProperty("Frames"),typeof(Regulus.SlitherLike.Logic.Common.IEntity).GetProperty("Position"),typeof(Regulus.SlitherLike.Logic.Common.IEntity).GetProperty("Speed"),typeof(Regulus.SlitherLike.Logic.Common.IEntity).GetProperty("Rotation"),typeof(Regulus.SlitherLike.Logic.Common.IPlay).GetProperty("Frames"),typeof(Regulus.SlitherLike.Logic.Common.IPlayer).GetProperty("Id"),typeof(Regulus.SlitherLike.Logic.Common.IPlayer).GetProperty("Name"),typeof(Regulus.SlitherLike.Logic.Common.IPlayer).GetProperty("Entities"),typeof(Regulus.SlitherLike.Logic.Common.IUser).GetProperty("Logins"),typeof(Regulus.SlitherLike.Logic.Common.IUser).GetProperty("Plays"),typeof(Regulus.SlitherLike.Logic.Common.IUser).GetProperty("Players"),typeof(Regulus.SlitherLike.Logic.Common.IWorld).GetProperty("Frames") }, new System.Tuple<System.Type, System.Func<Regulus.Remote.IProvider>>[] {new System.Tuple<System.Type, System.Func<Regulus.Remote.IProvider>>(typeof(Regulus.SlitherLike.Logic.Common.IEntity),()=>new Regulus.Remote.TProvider<Regulus.SlitherLike.Logic.Common.IEntity>()),new System.Tuple<System.Type, System.Func<Regulus.Remote.IProvider>>(typeof(Regulus.SlitherLike.Logic.Common.ILogin),()=>new Regulus.Remote.TProvider<Regulus.SlitherLike.Logic.Common.ILogin>()),new System.Tuple<System.Type, System.Func<Regulus.Remote.IProvider>>(typeof(Regulus.SlitherLike.Logic.Common.IPlay),()=>new Regulus.Remote.TProvider<Regulus.SlitherLike.Logic.Common.IPlay>()),new System.Tuple<System.Type, System.Func<Regulus.Remote.IProvider>>(typeof(Regulus.SlitherLike.Logic.Common.IPlayer),()=>new Regulus.Remote.TProvider<Regulus.SlitherLike.Logic.Common.IPlayer>()),new System.Tuple<System.Type, System.Func<Regulus.Remote.IProvider>>(typeof(Regulus.SlitherLike.Logic.Common.IUser),()=>new Regulus.Remote.TProvider<Regulus.SlitherLike.Logic.Common.IUser>()),new System.Tuple<System.Type, System.Func<Regulus.Remote.IProvider>>(typeof(Regulus.SlitherLike.Logic.Common.IWorld),()=>new Regulus.Remote.TProvider<Regulus.SlitherLike.Logic.Common.IWorld>())});
                    }
                    System.Reflection.Assembly Regulus.Remote.IProtocol.Base => _Base;
                    byte[] Regulus.Remote.IProtocol.VerificationCode { get { return new byte[]{200,221,5,157,217,22,216,169,234,213,36,130,129,20,17,79};} }
                    Regulus.Remote.InterfaceProvider Regulus.Remote.IProtocol.GetInterfaceProvider()
                    {
                        return _InterfaceProvider;
                    }

                    Regulus.Remote.EventProvider Regulus.Remote.IProtocol.GetEventProvider()
                    {
                        return _EventProvider;
                    }

                    Regulus.Serialization.ISerializer Regulus.Remote.IProtocol.GetSerialize()
                    {
                        return _Serializer;
                    }

                    Regulus.Remote.MemberMap Regulus.Remote.IProtocol.GetMemberMap()
                    {
                        return _MemberMap;
                    }
                    
                }
            
            