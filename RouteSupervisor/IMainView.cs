using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteSupervisor
{
    interface IMainView
    {
        event EventHandler<StringEventArgs> OnAddBlankRoute;
        event EventHandler<StringEventArgs> OnLoadRoutes;
        event EventHandler OnRecalculateAllRoutes;
        event EventHandler<StringEventArgs> OnRouteViewChanged;
        event EventHandler<StringEventArgs> OnSaveAsRoutes;
        event EventHandler OnSaveRoutes;
        event EventHandler OnViewSummary;

        void AddRouteView(string routeId, IRouteView routeView);
        void ClearAll();
        void EnableDisableSave(bool isEnabled);
        void Launch();
        void SelectRoute(string routeId);
        void ShowError(string message);
        void ShowMessage(string message);
    }
}
