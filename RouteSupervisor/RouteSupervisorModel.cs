using EO.WebBrowser.WinForm;
using SS2.Extensions.Services.Maps;
using System;
using System.Collections.Generic;

namespace RouteSupervisor
{
    class RouteSupervisorModel
    {
        List<AllMedRoute> _routes = new List<AllMedRoute>();
        readonly IRouteRepository _routeRepository = new DefaultFileRouteRepository();

        private void setStopValues(AllMedStop stop, Guid id, string description, string street, string city, string state, string postalCode, int numberDrops, double latitude, double longitude)
        {
            stop.Id = id;
            stop.Description = description;
            stop.Street = street;
            stop.City = city;
            stop.State = state;
            stop.PostalCode = postalCode;
            stop.NumberDrops = numberDrops;
            stop.Latitude = latitude;
            stop.Longitude = longitude;
        }

        public AllMedRoute CurrentlySelectedRouter { get; set; }
        public List<AllMedStop> CurrentlySelectedStops
        {
            get { return this.CurrentlySelectedRouter.Stops; }
            set { this.CurrentlySelectedRouter.Stops = value; }
        }
        public List<AllMedRoute> Routes
        {
            get { return _routes; }
        }
        public string SavedFileFullPath { get; set; }

        public void AddBlankRoute(string routerId)
        {
            AllMedRoute newRouter = new AllMedRoute();
            newRouter.Description = routerId;
            newRouter.MapSource = SS2MapSource.Google;
            newRouter.APIKey = "AIzaSyDPHZWupfbT2WMeJtvzeRjkBFBqf2PEACQ";
            newRouter.RoutingMethod = RoutingMethod.Optimize;
            newRouter.IsRoundTrip = true;

            _routes.Add(newRouter);
            this.CurrentlySelectedRouter = newRouter;
        }
        public void AddStop(string description, string street, string city, string state, string postalCode, int numberDrops, double latitude, double longitude)
        {
            AllMedStop newStop = new AllMedStop();
            setStopValues(newStop, Guid.NewGuid(), description, street, city, state, postalCode, numberDrops, latitude, longitude);
            this.CurrentlySelectedRouter.Stops.Add(newStop);
        }
        public void DeleteStop(Guid id)
        {
            this.CurrentlySelectedRouter.Stops.Remove(this.CurrentlySelectedRouter.GetDeliveryPoint(id));
        }
        public void EditStop(Guid id, string description, string street, string city, string state, string postalCode, int numberDrops, double latitude, double longitude)
        {
            setStopValues(this.CurrentlySelectedRouter.GetDeliveryPoint(id), id, description, street, city, state, postalCode, numberDrops, latitude, longitude);
        }
        public SS2MapNamedLocation GetGeocode(string street, string city, string state, string postalCode)
        {
            List<SS2MapNamedLocation> geocodes = SS2GoogleMaps.GetGeocode(street, city, state, postalCode, this.CurrentlySelectedRouter.APIKey);
            if (geocodes.Count == 1)
            {
                return new SS2MapNamedLocation(geocodes[0].Latitude, geocodes[0].Longitude);
            }
            else
            {
                throw new MultipleGeocodesException(geocodes);
            }
        }
        public AllMedRoute GetRoute(string routerId)
        {
            return _routes.Find(t => t.Description == routerId);
        }
        public void LoadRoutes(string fullPath)
        {
            this.SavedFileFullPath = fullPath;
            _routes = _routeRepository.LoadRoutes(fullPath);

            if (_routes.Count > 0)
            {
                foreach (AllMedRoute route in _routes)
                {
                    route.Time = route.Time_Serialized;
                }
                this.CurrentlySelectedRouter = _routes[0];
            }
        }
        public void MoveStop(int originalIndex, int newIndex)
        {
            var stop = this.CurrentlySelectedRouter.Stops[originalIndex];

            this.CurrentlySelectedRouter.Stops.RemoveAt(originalIndex);
            this.CurrentlySelectedRouter.Stops.Insert(newIndex, stop);
        }
        public void ReorderCurrentStops()
        {
            int subtract = (!this.CurrentlySelectedRouter.IsRoundTrip ? 1 : 0) + 1;

            AllMedStop[] wayPointsArray = new AllMedStop[this.CurrentlySelectedStops.Count - subtract];
            this.CurrentlySelectedStops.CopyTo(1, wayPointsArray, 0, this.CurrentlySelectedStops.Count - subtract);

            List<AllMedStop> tempList = new List<AllMedStop>(wayPointsArray);
            for (int i = 0; i < this.CurrentlySelectedRouter.Legs.Count - 1; i++)
            {
                tempList[this.CurrentlySelectedRouter.Legs[i].DestinationIndex].Index = i;
            }
            tempList.Sort( (t1, t2) => (t1.Index.CompareTo(t2.Index)) );

            tempList.Insert(0, this.CurrentlySelectedRouter.Stops[0]);
            if (!this.CurrentlySelectedRouter.IsRoundTrip)
            {
                tempList.Add(this.CurrentlySelectedStops[this.CurrentlySelectedStops.Count - 1]);
            }
            this.CurrentlySelectedStops = tempList;
        } 
        public void SaveAsRoute(string fullPath)
        {
            this.SavedFileFullPath = fullPath;
            this.SaveRoutes();
        }
        public void SaveRoutes()
        {
            foreach (AllMedRoute route in _routes)
            {
                route.Time_Serialized = route.Time;
            }
            _routeRepository.SaveRoutes(_routes, this.SavedFileFullPath);
        }
        public void SetCurrentlySelectedRouter(string routeId)
        {
            this.CurrentlySelectedRouter = this.GetRoute(routeId);
        }
        public void SetIsRoundTrip(bool isRoundTrip)
        {
            this.CurrentlySelectedRouter.IsRoundTrip = isRoundTrip;
        }
        public void SetRoutingMethod(RoutingMethod routingMethod)
        {
            this.CurrentlySelectedRouter.RoutingMethod = routingMethod;
        }
        public void ShowMap(RoutingMethod routingMethod, bool isRoundTrip, WebControl webControl)
        {
            if (isRoundTrip)
            {
                var origin = this.CurrentlySelectedRouter.Stops[0];
                var destination = new AllMedStop(
                    origin.Latitude
                    , origin.Longitude
                    , origin.Street
                    , origin.State
                    , origin.City
                    , origin.PostalCode
                );
                destination.Id = origin.Id;
                destination.Description = origin.Description;

                this.CurrentlySelectedRouter.Stops.Add(destination);
            }
            this.CurrentlySelectedRouter.Route(routingMethod == RoutingMethod.Optimize, true, webControl);

            if (isRoundTrip)
            {
                this.CurrentlySelectedRouter.Stops.RemoveAt(this.CurrentlySelectedRouter.Stops.Count-1);
            }
        }

        public RouteSupervisorModel()
        {
            EO.WebBrowser.Runtime.AddLicense(
                "G9f3tGyuvcH50WmwusXjs4+zs/0U4p7l9/b043eEjrHLn1mz8PoO5Kfq6fbp" +
                "wJrp8//LwqHY8vjnrqXg5/YZ8p7cwp61n1mXpM0M66Xm+8+4iVmXpLHLn1mX" +
                "wPIP41nr/QEQvFu807/u56vm8fbNn6/c9gQU7qe0psLgrWmZpMDpjEOXpLHL" +
                "u2jY8P0a9neEjrHLn1mz8wMP5KvA8vcan53Y+PbooWumtsDdr2qtprEe9Ju8" +
                "/AEU8Z7qxQXooWumtsDdr2quprEh5Kvq7QAZvFuoubPLrneEjrHLn1mz9/oS" +
                "7Zrr+QMQvarby+DhyoHJuAQf5mnt0AYPyG3b9uLovHWm9/oS7Zrr+QMQvUaB" +
                "wMAX6Jzc8gQQvUaBdePt9BDtrNzCnrWfWZekzRfonNzyBBDInbW4");
        }
    }
}