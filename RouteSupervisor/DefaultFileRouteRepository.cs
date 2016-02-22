using Newtonsoft.Json;
using SS2.Extensions.Services.Maps;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RouteSupervisor
{
    class DefaultFileRouteRepository : IRouteRepository
    {
        List<AllMedStop> _stops = new List<AllMedStop>();

        private void setMockDataWithGeocodes()
        {
            var origin = new AllMedStop(29.735190, -95.402986, "1722 Colquitt St.", "Houston", "TX", "77098");
            origin.Description = "House";
            var wayPoint1 = new AllMedStop(29.723229, -95.385316, "5506 La Branch St.", "Houston", "TX", "77004");
            wayPoint1.Description = "CM";
            var wayPoint2 = new AllMedStop(29.898562, -95.641385, "8203 Town Creek Dr.", "Houston", "TX", "77095");
            wayPoint2.Description = "Parents";

            _stops.Clear();
            _stops.Add(origin);
            _stops.Add(wayPoint1);
            _stops.Add(wayPoint2);
        }
        private void setMockDataWithoutGeocodes()
        {
            var origin = new AllMedStop(0, 0, "1722 Colquitt St.", "Houston", "TX", "77098");
            origin.Description = "House";
            var wayPoint1 = new AllMedStop(0, 0, "5506 La Branch St.", "Houston", "TX", "77004");
            wayPoint1.Description = "CM";
            var wayPoint2 = new AllMedStop(0, 0, "8203 Town Creek Dr.", "Houston", "TX", "77095");
            wayPoint2.Description = "Parents";

            _stops.Clear();
            _stops.Add(origin);
            _stops.Add(wayPoint1);
            _stops.Add(wayPoint2);
        }
        public List<AllMedStop> GetStops()
        {
            return _stops;
        }
        public List<AllMedRoute> LoadRoutes(string fullPath)
        {
            return JsonConvert.DeserializeObject<List<AllMedRoute>>(File.ReadAllText(fullPath));
        }
        public void SaveRoutes(List<AllMedRoute> routers, string fullPath)
        {
            using (FileStream file = new FileStream(fullPath, FileMode.Create))
            {
                byte[] data = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(routers));
                file.Write(data, 0, data.Length);
            }
        }
        public DefaultFileRouteRepository()
        {
//            setMockDataWithoutGeocodes();
        }
    }
}