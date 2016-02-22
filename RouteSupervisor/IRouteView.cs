using SS2.Extensions.Services.Maps;
using System;
using System.Collections.Generic;

namespace RouteSupervisor
{
    public interface IRouteView
    {
        event EventHandler OnAddStop;
        event EventHandler<CalculateRouteEventArgs> OnCalculateRoute;
        event EventHandler<GuidEventArgs> OnEditStop;
        event EventHandler OnDeleteAllStops;
        event EventHandler<GuidEventArgs> OnDeleteStop;
        event EventHandler<MoveStopEventArgs> OnMoveStop;
        event EventHandler<AddStopsEventArgs> OnPasteStops;
        event EventHandler<BoolEventArgs> OnIsRoundTripChanged;
        event EventHandler<RoutingMethodEventArgs> OnRoutingMethodChanged;

        void ClearAll();
        void PopulateRoute(List<AllMedStop> stops);
        void Route();
        void SelectStop(int index);
        void SetDefaults();
        void SetRoutingMethod(RoutingMethod routingMethod);
        void UpdateRouteStatistics(string formattedDuration, string formattedStopTime, double distance);
    }
}
