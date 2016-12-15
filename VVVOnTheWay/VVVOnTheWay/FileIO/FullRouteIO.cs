﻿using Newtonsoft.Json;
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
        public readonly static string BlindWallsFileName = "BlindwallsRoute";

        /// <summary>
        /// The filepath of the Historical Kilometer route file
        /// </summary>
        public readonly static string HistoricalKilometerFileName = "HistoricalKilometerRoute";

        /// <summary>
        /// Loads/creates the Historical Kilometer Route, which can be retrieved as this class' attributes
        /// </summary>
        /// <returns>The Route object for the Historical Kilometer route</returns>
        public async static Task<Route.Route> LoadHistoricalKilometerRoute()
        {
            StorageFolder datafolder = ApplicationData.Current.LocalFolder;
            try
            {
                StorageFile HistoricalKilometerFile = await datafolder.GetFileAsync($"{HistoricalKilometerFileName}.json");
                string json = await Windows.Storage.FileIO.ReadTextAsync(HistoricalKilometerFile);
                Route.Route retrievedRoute = JsonConvert.DeserializeObject<Route.Route>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                return retrievedRoute;
            }
            catch (FileNotFoundException)
            {
                var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(@"Assets\HistoricalKilometerFullRoute.json");
                await file.CopyAsync(datafolder, $"{HistoricalKilometerFileName}", NameCollisionOption.ReplaceExisting);
                string json = await Windows.Storage.FileIO.ReadTextAsync(file);
                Route.Route retrievedRoute = JsonConvert.DeserializeObject<Route.Route>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                return retrievedRoute;
            }
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
