using EO.WebBrowser.WinForm;
using SS2.Extensions.Services.Maps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RouteSupervisor
{
    public class AllMedRoute : SS2MapRouter
    {
        public string Description { get; set; }
        public bool IsRoundTrip { get; set; }
        public RoutingMethod RoutingMethod { get; set; }
        public uint Time_Serialized { get; set; }
        public string FormattedStopTime
        {
            get 
            { 
                TimeSpan timeSpan = new TimeSpan(0, this.getStopDuration(), 0);
                return string.Format("{0}{1}:{2}", timeSpan.Days > 0 ? string.Format("{0} day{1}, ", timeSpan.Days, timeSpan.Days > 1 ? "s" : "") : "", timeSpan.Hours.ToString().PadLeft(2, '0'), timeSpan.Minutes.ToString().PadLeft(2, '0'));
            }
        }

        public List<AllMedStop> Stops { get; set; }

        public AllMedStop GetDeliveryPoint(Guid id)
        {
            return this.Stops.Find(dp => dp.Id == id);
        }
        private int getStopDuration()
        {
            int stopDuration = 0;
            foreach (AllMedStop stop in this.Stops)
            {
                stopDuration += stop.NumberDrops * 10;
            }
            return stopDuration;
        }
        public new void Reset()
        {
            this.Stops.Clear();
            base.Reset();
        }
        public new void Route(bool useOptimization, bool showMap, WebControl webControl)
        {
            base.DeliveryPoints = this.Stops.Cast<SS2MapDeliveryPoint>().ToList();
            base.Route(useOptimization, showMap, webControl);
        }
        public AllMedRoute()
        {
            this.Stops = new List<AllMedStop>();
        }
    }
    public enum RoutingMethod { Optimize, AsIs }
}
