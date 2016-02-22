using EO.WebBrowser.WinForm;
using SS2.Extensions.Services.Maps;
using System;
using System.Collections.Generic;

namespace RouteSupervisor
{
    class RouteSupervisorPresenter
    {
        RouteSupervisorModel _model;

        readonly IMainView _mainView;
        readonly IDictionary<string, IRouteView> _routeViews;
        readonly ISummaryView _summaryView;
        readonly IStopView _stopView;

        IRouteView currentlySelectedRouteView 
        {
            get { return _routeViews[_model.CurrentlySelectedRouter.Description]; }
        }
        private void addNewRouteView(string routeId)
        {
            IRouteView newRouteView = new SplitRouteView();
            attachRouteViewEventHandlers(newRouteView);

            _routeViews.Add(routeId, newRouteView);
            _mainView.AddRouteView(routeId, newRouteView);
        }
        private void attachMainViewEventHandlers()
        {
            _mainView.OnAddBlankRoute += mainView_OnAddBlankRoute;
            _mainView.OnLoadRoutes += mainView_OnLoadRoutes;
            _mainView.OnRecalculateAllRoutes += mainView_OnRecalculateAllRoutes;
            _mainView.OnRouteViewChanged += mainView_OnRouteViewChanged;
            _mainView.OnSaveAsRoutes += mainView_OnSaveAsRoutes;
            _mainView.OnSaveRoutes += mainView_OnSaveRoutes;
            _mainView.OnViewSummary += mainView_OnViewSummary;
        }

        void mainView_OnViewSummary(object sender, EventArgs e)
        {
            _summaryView.PopulateRoutes(_model.Routes);
            _summaryView.Launch();
        }
        private void attachRouteViewEventHandlers(IRouteView routeView)
        {
            routeView.OnAddStop += routeView_OnAddStop;
            routeView.OnCalculateRoute += routeView_OnCalculateRoute;
            routeView.OnDeleteAllStops += routeView_OnDeleteAllStops;
            routeView.OnDeleteStop += routeView_OnDeleteStop;
            routeView.OnEditStop += routeView_OnEditStop;
            routeView.OnIsRoundTripChanged += routeView_OnIsRoundTripChanged;
            routeView.OnMoveStop += routeView_OnMoveStop;
            routeView.OnPasteStops += stopView_OnAddStops;
            routeView.OnRoutingMethodChanged += routeView_OnRoutingMethodChanged;
        }
        private void attachStopViewEventHandlers()
        {
            _stopView.OnAddStop += stopView_OnAddStops;
            _stopView.OnEditStop += stopView_OnEditStop;
            _stopView.OnGeocodeStop += stopView_OnGeocodeStop;
        }
        private void updateAllRouteStatistics()
        {
            foreach (AllMedRoute route in _model.Routes)
            {
                _routeViews[route.Description].UpdateRouteStatistics(route.FormattedTime, route.FormattedStopTime, route.Distance);
            }
        }

        void CurrentlySelectedRouter_OnRouteLegsAssigned(object sender, EventArgs e)
        {
            _model.CurrentlySelectedRouter.OnRouteLegsAssigned -= CurrentlySelectedRouter_OnRouteLegsAssigned;

            this.currentlySelectedRouteView.UpdateRouteStatistics(_model.CurrentlySelectedRouter.FormattedTime, _model.CurrentlySelectedRouter.FormattedStopTime, _model.CurrentlySelectedRouter.Distance);
            if (_model.CurrentlySelectedRouter.Legs.Count > 2)
            {
                _model.ReorderCurrentStops();
                this.currentlySelectedRouteView.PopulateRoute(_model.CurrentlySelectedStops);
            }
            this.currentlySelectedRouteView.SelectStop(-1);
        }
        void CurrentlySelectedRouter_OnStopSelected(object sender, IntEventArgs e)
        {
            this.currentlySelectedRouteView.SelectStop(e.Value);
        }

        void routeView_OnAddStop(object sender, EventArgs e)
        {
            _stopView.Launch(true);
        }
        void routeView_OnCalculateRoute(object sender, CalculateRouteEventArgs e)
        {
            _model.CurrentlySelectedRouter.OnRouteLegsAssigned += this.CurrentlySelectedRouter_OnRouteLegsAssigned;
            _model.CurrentlySelectedRouter.OnStopSelected += this.CurrentlySelectedRouter_OnStopSelected;
            _model.ShowMap(e.RoutingMethod, e.IsRoundTrip, e.WebControl);
        }
        void routeView_OnDeleteAllStops(object sender, EventArgs e)
        {
            _model.CurrentlySelectedRouter.Reset();
            this.currentlySelectedRouteView.ClearAll();
            this.currentlySelectedRouteView.SetDefaults();
        }
        void routeView_OnDeleteStop(object sender, GuidEventArgs e)
        {
            _model.DeleteStop(e.Value);
            this.currentlySelectedRouteView.PopulateRoute(_model.CurrentlySelectedStops);
        }
        void routeView_OnEditStop(object sender, GuidEventArgs e)
        {
            AllMedStop stop = _model.CurrentlySelectedRouter.GetDeliveryPoint(e.Value);
            _stopView.PopulateStop(
                stop.Id
                , stop.Description
                , stop.Street
                , stop.City
                , stop.State
                , stop.PostalCode
                , stop.Latitude
                , stop.Longitude
            );
            _stopView.Launch(false);
        }
        void routeView_OnIsRoundTripChanged(object sender, BoolEventArgs e)
        {
            _model.SetIsRoundTrip(e.Value);
        }
        void routeView_OnMoveStop(object sender, MoveStopEventArgs e)
        {
            _model.MoveStop(e.OriginalIndex, e.NewIndex);
            this.currentlySelectedRouteView.SelectStop(e.NewIndex);
        }
        void routeView_OnRoutingMethodChanged(object sender, RoutingMethodEventArgs e)
        {
            _model.SetRoutingMethod(e.Value);
        }

        void mainView_OnAddBlankRoute(object sender, StringEventArgs e)
        {
            _model.AddBlankRoute(e.Value);
            this.addNewRouteView(e.Value);
            this.mainView_OnRouteViewChanged(sender, e);
        }
        void mainView_OnLoadRoutes(object sender, StringEventArgs e)
        {
            _model.LoadRoutes(e.Value);
            if (_model.Routes.Count > 0)
            {
                _mainView.ClearAll();
                _routeViews.Clear();

                foreach (AllMedRoute route in _model.Routes)
                {
                    this.addNewRouteView(route.Description);
                    _model.CurrentlySelectedRouter = route;
                    this.currentlySelectedRouteView.PopulateRoute(route.Stops);
                    this.currentlySelectedRouteView.SetRoutingMethod(route.RoutingMethod);
                    this.currentlySelectedRouteView.Route();
                }
                this.updateAllRouteStatistics();
                _mainView.SelectRoute(_model.Routes[0].Description);
            }
        }
        void mainView_OnRecalculateAllRoutes(object sender, EventArgs e)
        {
            foreach (SS2MapRouter route in _model.Routes)
            {
                this.currentlySelectedRouteView.Route();
            }
            this.updateAllRouteStatistics();
        }
        void mainView_OnRouteViewChanged(object sender, StringEventArgs e)
        {
            _model.SetCurrentlySelectedRouter(e.Value);
        }
        void mainView_OnSaveAsRoutes(object sender, StringEventArgs e)
        {
            _model.SaveAsRoute(e.Value);
            _mainView.ShowMessage(string.Format("Route saved to [{0}]", e.Value));
        }
        void mainView_OnSaveRoutes(object sender, EventArgs e)
        {
            _model.SaveRoutes();
            _mainView.ShowMessage(string.Format("Route saved to [{0}]", _model.SavedFileFullPath));
        }

        void stopView_OnAddStops(object sender, AddStopsEventArgs e)
        {
            if (e.ReplaceExistingStops)
            {
                _model.CurrentlySelectedRouter.Reset();
                this.currentlySelectedRouteView.ClearAll();
            }
            foreach (AddEditStopEventArgs stopEventArgs in e.AddEditStopEventArgs)
            {
                _model.AddStop(
                    stopEventArgs.Description
                    , stopEventArgs.Street
                    , stopEventArgs.City
                    , stopEventArgs.State
                    , stopEventArgs.PostalCode
                    , stopEventArgs.NumberDrops
                    , stopEventArgs.Latitude
                    , stopEventArgs.Longitude
                );
            }
            this.currentlySelectedRouteView.PopulateRoute(_model.CurrentlySelectedStops);

            if (e.AddEditStopEventArgs.Count > 0)
            {
                _mainView.EnableDisableSave(true);
            }
        }
        void stopView_OnEditStop(object sender, AddEditStopEventArgs e)
        {
            _model.EditStop(
                e.Id
                , e.Description
                , e.Street
                , e.City
                , e.State
                , e.PostalCode
                , e.NumberDrops
                , e.Latitude
                , e.Longitude
            );
        }
        void stopView_OnGeocodeStop(object sender, GeocodeStopEventArgs e)
        {
            SS2MapNamedLocation geocode = _model.GetGeocode(e.Street, e.City, e.State, e.PostalCode);
            _stopView.PopulateGeocode(geocode.Latitude, geocode.Longitude);
        }
        void stopView_OnSelectedRouteChanged(object sender, StringEventArgs e)
        {
            _model.CurrentlySelectedRouter = _model.GetRoute(e.Value);
            this.currentlySelectedRouteView.PopulateRoute(_model.CurrentlySelectedStops);
        }

        void unattachMainViewEventHandlers()
        {
            _mainView.OnAddBlankRoute -= mainView_OnAddBlankRoute;
            _mainView.OnLoadRoutes -= mainView_OnLoadRoutes;
            _mainView.OnRecalculateAllRoutes -= mainView_OnRecalculateAllRoutes;
            _mainView.OnRouteViewChanged -= mainView_OnRouteViewChanged;
            _mainView.OnSaveAsRoutes -= mainView_OnSaveAsRoutes;
            _mainView.OnSaveRoutes -= mainView_OnSaveRoutes;
            _mainView.OnViewSummary -= mainView_OnViewSummary;
            _model.CurrentlySelectedRouter.OnStopSelected -= this.CurrentlySelectedRouter_OnStopSelected;
        }
        void unattachRouteViewEventHandlers()
        {
            foreach (IRouteView routeView in _routeViews.Values)
            {
                routeView.OnAddStop -= routeView_OnAddStop;
                routeView.OnCalculateRoute -= routeView_OnCalculateRoute;
                routeView.OnDeleteAllStops -= routeView_OnDeleteAllStops;
                routeView.OnDeleteStop -= routeView_OnDeleteStop;
                routeView.OnEditStop -= routeView_OnEditStop;
                routeView.OnIsRoundTripChanged -= routeView_OnIsRoundTripChanged;
                routeView.OnMoveStop -= routeView_OnMoveStop;
                routeView.OnPasteStops -= stopView_OnAddStops;
                routeView.OnRoutingMethodChanged -= routeView_OnRoutingMethodChanged;
            }
        }
        void unattachStopViewEventHandlers()
        {
            _stopView.OnAddStop += stopView_OnAddStops;
            _stopView.OnEditStop += stopView_OnEditStop;
            _stopView.OnGeocodeStop += stopView_OnGeocodeStop;
        }

        public RouteSupervisorPresenter()
        {
            _model = new RouteSupervisorModel();
            _mainView = new MainView();
            _routeViews = new Dictionary<string, IRouteView>();
            _summaryView = new WinFormsSummaryView();
            _stopView = new WinFormsStopView();

            attachMainViewEventHandlers();
            attachSummaryViewEventHandlers();
            attachStopViewEventHandlers();

            _mainView.Launch();

            unattachStopViewEventHandlers();
            unattachSummaryViewEventHandlers();
            unattachRouteViewEventHandlers();
            unattachMainViewEventHandlers();
        }

        private void unattachSummaryViewEventHandlers()
        {
            _summaryView.OnViewRoute -= summaryView_OnViewRoute;
        }

        private void attachSummaryViewEventHandlers()
        {
            _summaryView.OnViewRoute += summaryView_OnViewRoute;
        }

        void summaryView_OnViewRoute(object sender, StringEventArgs e)
        {
            _model.SetCurrentlySelectedRouter(e.Value);
            this.mainView_OnRouteViewChanged(sender, new StringEventArgs(e.Value));
        }
    }

    public class AddEditStopEventArgs : GeocodeStopEventArgs
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int NumberDrops { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public AddEditStopEventArgs(Guid id, string description, string street, string city, string state, string postalCode, int numberDrops, double latitude, double longitude)
            : this(description, street, city, state, postalCode, numberDrops, latitude, longitude)
        {
            this.Id = id;
        }
        
        public AddEditStopEventArgs(string description, string street, string city, string state, string postalCode, int numberDrops, double latitude, double longitude)
            : base(street, city, state, postalCode)
        {
            this.Description = description;
            this.Street = street;
            this.City = city;
            this.State = state;
            this.PostalCode = postalCode;
            this.NumberDrops = numberDrops;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
    }

    public class AddStopsEventArgs : EventArgs
    {
        public List<AddEditStopEventArgs> AddEditStopEventArgs { get; set; }
        public bool ReplaceExistingStops { get; set; }

        public AddStopsEventArgs(List<AddEditStopEventArgs> list, bool replaceExistingStops)
        {
            this.AddEditStopEventArgs = list;
            this.ReplaceExistingStops = replaceExistingStops;
        }
    }

    public class BoolEventArgs : EventArgs
    {
        public bool Value { get; set; }

        public BoolEventArgs(bool value)
        {
            this.Value = value;
        }
    }

    public class CalculateRouteEventArgs : EventArgs
    {
        public RoutingMethod RoutingMethod { get; set; }
        public bool IsRoundTrip { get; set; }
        public WebControl WebControl { get; set; }

        public CalculateRouteEventArgs(RoutingMethod routingMethod, bool isRoundTrip, WebControl webControl)
        {
            this.RoutingMethod = routingMethod;
            this.IsRoundTrip = isRoundTrip;
            this.WebControl = webControl;
        }
    }

    public class GeocodeStopEventArgs : EventArgs
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        public GeocodeStopEventArgs(string street, string city, string state, string postalCode)
        {
            this.Street = street;
            this.City = city;
            this.State = state;
            this.PostalCode = postalCode;
        }
    }

    public class GuidEventArgs : EventArgs
    {
        public Guid Value { get; set; }

        public GuidEventArgs(Guid value)
        {
            this.Value = value;
        }
    }

    public class MoveStopEventArgs : EventArgs
    {
        public int OriginalIndex { get; set; }
        public int NewIndex { get; set; }

        public MoveStopEventArgs(int originalIndex, int newIndex)
        {
            this.OriginalIndex = originalIndex;
            this.NewIndex = newIndex;
        }
    }

    public class RoutingMethodEventArgs : EventArgs
    {
        public RoutingMethod Value { get; set; }

        public RoutingMethodEventArgs(RoutingMethod routingMethod)
        {
            this.Value = routingMethod;
        }
    }

    public class StringEventArgs: EventArgs
    {
        public string Value { get; set; }

        public StringEventArgs(string value)
        {
            this.Value = value;
        }
    }

    class MultipleGeocodesException : Exception
    {
        List<SS2MapNamedLocation> Geocodes { get; set; }

        public MultipleGeocodesException(List<SS2MapNamedLocation> geocodes)
        {
            this.Geocodes = geocodes;
        }
    }

    class InvalidGeocodeException : Exception { }
}