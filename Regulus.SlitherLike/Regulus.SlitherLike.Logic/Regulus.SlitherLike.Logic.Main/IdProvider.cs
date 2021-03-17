using Regulus.Remote;

namespace Regulus.SlitherLike.Logic.Main
{
    class IdProvider :  ILandlordProviable<long>
    {
        long _Ids;
        public readonly Regulus.Remote.Landlord<long> Provider;
        public IdProvider() 
        {
            Provider = new Landlord<long>(this);
        }

        long ILandlordProviable<long>.Spawn()
        {
            return ++_Ids;
        }
    }
}