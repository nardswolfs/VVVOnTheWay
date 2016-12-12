using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVVOnTheWay.Route;
using Windows.Storage;

namespace VVVOnTheWay.FileIO
{
    class FullRouteIOTest
    {
        public FullRouteIOTest()
        {
            Route.RouteTest routetest = new Route.RouteTest();
            List<Point> poi = routetest.PointsOfInterest;
            
            TestMethod(poi);
        }

        public void TestMethod(object totest)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string s = JsonConvert.SerializeObject(totest, settings);
            WriteJson(s);
            ReadJson(settings);
        }

        async void WriteJson(string s)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await localFolder.CreateFileAsync($"jsontest.json", CreationCollisionOption.ReplaceExisting);
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, s);
            Debug.WriteLine("Did it");
        }

        async void ReadJson(JsonSerializerSettings settings)
        {
            try
            {
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile sampleFile = await localFolder.GetFileAsync("jsontest.json");
                string json = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
                List<Point> list = JsonConvert.DeserializeObject<List<Point>>(json, settings);
                Debug.WriteLine(list[2]);
            } 
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
    }
}
