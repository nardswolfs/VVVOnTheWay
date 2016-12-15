using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using LocationSystem;
using VVVOnTheWay.Route;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VVVOnTheWay
{

    
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapPage : Page
    {
        private Route.Route route;
        private MapIcon _userIcon;
        private MapRouteView _routeView;
        private Language _language;

        public MapPage(Route.Route route)
        {
            this.InitializeComponent();
            this.route = route;
            GetUserLocation();
            AddPointsOfInterest();
            
        }

        private async Task GetUserLocation()
        {
            try
            {
                var location = await BingMapsWrapper.getCurrentPosition();
                Map.Center = location.Coordinate.Point;
                Map.ZoomLevel = 15;
                UpdateUserLocation(location);
            }
            catch (GPSNotAllowed)
            {
                await new MessageDialog("No GPS Access!", "GPS not functional!").ShowAsync();
                // TODO take action when no gps
                // TODO show in language which is chosen
            }
            BingMapsWrapper.notifyOnLocationUpdate((geoposition =>
            {
                UpdateUserLocation(geoposition);

                // TODO CHECK IF DISPATCHER IS NEEDED BECAUSE OTHER THREAD
                return null;
            }));
            
        }

        private void UpdateUserLocation(Geoposition geoposition)
        {
            if (_userIcon == null)
            {
                _userIcon = new MapIcon()
                {
                    Title = "Your Location",
                    Location = geoposition.Coordinate.Point
                };
                Map.MapElements.Add(_userIcon);
            }
            else
            {
                _userIcon.Location = geoposition.Coordinate.Point;
            }
        }

        private void LoadRoute()
        {
            
        }
    

        private void AddPointsOfInterest()
        {
            foreach (PointOfInterest poi in route.PointsOfInterest)
            {
                Map.MapElements.Add(new MapIcon()
                {
                    Title = poi.Title[(int)_language],
                    Location = poi.Location

                });
            }
        }



        private void LanguageSwitch_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RouteSelectionPage));
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MapPage));
            //#TODO: Make GuidePage
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MapPage));
            //#TODO: Make GuidePage
        }

       
    }
}
