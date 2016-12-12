using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVVOnTheWay.FileIO
{
    class FullRouteIO
    {
        /// <summary>
        /// The filepath of the Blind Walls route file
        /// </summary>
        private string blindWallsFilePath { get; set; }

        /// <summary>
        /// The filepath of the Historical Kilometer route file
        /// </summary>
        private string historicalKilometerFilePath { get; set; }

        /// <summary>
        /// Constructs an new FullRouteIO object
        /// </summary>
        public FullRouteIO()
        {

        }

        /// <summary>
        /// Updates the existing routes information 
        /// </summary>
        /// <exception cref="System.Exception">Thrown when there is no WiFi internet connection available</exception>
        public void UpdateRoutes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the Historical Kilometer route
        /// </summary>
        public void UpdateHistoricalKilometerRoute()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the Blind Walls Route
        /// </summary>
        public void UpdateBlindWallsRoute()
        {
            throw new NotImplementedException();
        }

    }
}
