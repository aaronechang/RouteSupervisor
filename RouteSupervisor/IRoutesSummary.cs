using SS2.Extensions.Services.Maps;
using System;
using System.Collections.Generic;

namespace RouteSupervisor
{
    interface ISummaryView
    {
        event EventHandler<StringEventArgs> OnViewRoute;

        void Launch();
        void PopulateRoutes(List<AllMedRoute> routes);
    }
}
