using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace VVVOnTheWay.NotificationSystem
{
    /// <summary>
    /// A implementation of the INotification interface for specific use with the PointOfInterest class
    /// </summary>
    class PoiNotification : INotification
    {
        private string AudioPath { get; set; }
        private Image Image { get; set; }
        private string Description { get; set; }

        /// <summary>
        /// The constuctor of the PoiNotification
        /// </summary>
        //TODO add body if need be
        public PoiNotification()
        {
            throw new NotImplementedException();
        }
    }
}
