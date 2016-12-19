using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        public static readonly string BlindWallsFileName = "BlindwallsRoute";

        /// <summary>
        /// The filepath of the Historical Kilometer route file
        /// </summary>
        public static readonly string HistoricalKilometerFileName = "HistoricalKilometerRoute";

        /// <summary>
        /// Loads/creates the Historical Kilometer Route, which can be retrieved as this class' attributes
        /// </summary>
        /// <returns>The Route object for the Historical Kilometer route</returns>
        public static async Task<Route.Route> LoadRouteAsync(string routeFileName)
        {
            StorageFolder datafolder = ApplicationData.Current.LocalFolder;
            StorageFile routeFile;
            try
            {
                routeFile = await datafolder.GetFileAsync($"{routeFileName}.json");
            }
            catch (FileNotFoundException)
            {
                return await LoadRouteFromAssetsAsync(routeFileName);
            }
            string json = await Windows.Storage.FileIO.ReadTextAsync(routeFile);
            if (json == "") return await LoadRouteFromAssetsAsync(routeFileName);
            Route.Route retrievedRoute = JsonConvert.DeserializeObject<Route.Route>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            return retrievedRoute;
        }

        /// <summary>
        /// Loads/creates the Historical Kilometer Route, which can be retrieved as this class' attributes
        /// </summary>
        /// <returns>The Route object for the Historical Kilometer route</returns>
        public static async Task<Route.Route> LoadHistoricalKilometerRoute()
        {
            StorageFolder datafolder = ApplicationData.Current.LocalFolder;
            StorageFile historicalKilometerFile;
            try
            {
                historicalKilometerFile = await datafolder.GetFileAsync($"{HistoricalKilometerFileName}.json");
            }
            catch (FileNotFoundException)
            {
                return await LoadRouteFromAssetsAsync(HistoricalKilometerFileName);
            }
            string json = await Windows.Storage.FileIO.ReadTextAsync(historicalKilometerFile);
            if (json == "") return await LoadRouteFromAssetsAsync(HistoricalKilometerFileName);
            Route.Route retrievedRoute = JsonConvert.DeserializeObject<Route.Route>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            return retrievedRoute;
        }

        /// <summary>
        /// Loads/creates the Blind Walls Route, which can be retrieved as this class' attributes
        /// </summary>
        /// <returns>The Route object for the Blind Walls route</returns>
        public static async Task<Route.Route> LoadBlindWallsRoute()
        {
            StorageFolder datafolder = ApplicationData.Current.LocalFolder;
            StorageFile blindWallsRoute;
            try
            {
                blindWallsRoute = await datafolder.GetFileAsync($"{BlindWallsFileName}.json");
            }
            catch (FileNotFoundException)
            {
                return await LoadRouteFromAssetsAsync(BlindWallsFileName);
            }
            string json = await Windows.Storage.FileIO.ReadTextAsync(blindWallsRoute);
            if (json == "") return await LoadRouteFromAssetsAsync(BlindWallsFileName);
            Route.Route retrievedRoute = JsonConvert.DeserializeObject<Route.Route>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            return retrievedRoute;
        }

        private static async Task<Route.Route> LoadRouteFromAssetsAsync(string routeFileName)
        {
            StorageFolder datafolder = ApplicationData.Current.LocalFolder;
            StorageFile routeFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync($@"Assets\{routeFileName}.json");
            await routeFile.CopyAsync(datafolder, $"{routeFileName}.json", NameCollisionOption.ReplaceExisting);
            string json = await Windows.Storage.FileIO.ReadTextAsync(routeFile);
            Route.Route retrievedRoute = JsonConvert.DeserializeObject<Route.Route>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            return retrievedRoute;
        }

    }
}
