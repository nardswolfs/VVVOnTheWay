using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace VVVOnTheWay.FileIO
{
    /// <summary>
    /// Retrieves and distributes the information about RoutePoints of routes
    /// </summary>
    static class FullRouteIO
    {
        /// <summary>
        /// The filepath of the Blind Walls route file
        /// </summary>
        public readonly static string BlindWallsFilePath;

        /// <summary>
        /// The filepath of the Historical Kilometer route file
        /// </summary>
        public static string HistoricalKilometerFilePath { get; private set; }

        /// <summary>
        /// Loads/creates the Historical Kilometer Route, which can be retrieved as this class' attributes
        /// </summary>
        /// <returns>The Route object for the Historical Kilometer route</returns>
        public async static Task<Route.Route> LoadHistoricalKilometerRoute()
        {
            StorageFile HistoricalKilometerFile = await ApplicationData.Current.LocalFolder.GetFileAsync("historicalkilometer.json");
            HistoricalKilometerFilePath = HistoricalKilometerFile.Path;
            string json = await Windows.Storage.FileIO.ReadTextAsync(HistoricalKilometerFile);
            Route.Route retrievedRoute = JsonConvert.DeserializeObject<Route.Route>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads/creates the Blind Walls Route, which can be retrieved as this class' attributes
        /// </summary>
        /// <returns>The Route object for the Blind Walls route</returns>
        public static Route.Route LoadBlindWallsRoute()
        {
            throw new NotImplementedException();
        }

    }
}
