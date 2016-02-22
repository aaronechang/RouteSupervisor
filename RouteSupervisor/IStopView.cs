using System;

namespace RouteSupervisor
{
    interface IStopView
    {
        event EventHandler<AddStopsEventArgs> OnAddStop;
        event EventHandler<AddEditStopEventArgs> OnEditStop;
        event EventHandler<GeocodeStopEventArgs> OnGeocodeStop;

        void Launch(bool showNameField);
        void PopulateGeocode(double latitude, double longitude);
        void PopulateStop(Guid id, string description, string street, string city, string state, string postalCode, double latitude, double longitude);
        void showHideNameField(bool showNameField);
    }
}