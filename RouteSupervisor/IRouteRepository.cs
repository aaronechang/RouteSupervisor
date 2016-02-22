using SS2.Extensions.Services.Maps;
using System.Collections.Generic;

namespace RouteSupervisor
{
    interface IRouteRepository
    {
        List<AllMedRoute> LoadRoutes(string fulPath);
        List<AllMedStop> GetStops();
        void SaveRoutes(List<AllMedRoute> routers, string fullPath);
    }
}
