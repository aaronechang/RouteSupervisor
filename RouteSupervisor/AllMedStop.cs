using SS2.Extensions.Services.Maps;

namespace RouteSupervisor
{
    public class AllMedStop : SS2MapDeliveryPoint
    {
        public int Index { get; set; }
        public int NumberDrops { get; set; }

        public AllMedStop(double latitude, double longitude, string street, string city, string state, string postalCode)
            : base(latitude, longitude, street, city, state, postalCode) { }

        public AllMedStop() { }
    }
}
