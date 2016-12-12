using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVVOnTheWay.FileIO
{
    /// <summary>
    /// Retrieves and distributes the information about PointsOfInterest of routes
    /// </summary>
    class FullRouteIO
    {
        /// <summary>
        /// The filepath of the Blind Walls route file
        /// </summary>
        private readonly static string blindWallsFilePath;

        /// <summary>
        /// The filepath of the Historical Kilometer route file
        /// </summary>
        private readonly static string historicalKilometerFilePath;

        /// <summary>
        /// The Historical Kilometer Route object with its own information
        /// </summary>
        public readonly Route.Route HistoricalKilometerRoute;

        /// <summary>
        /// The Blind Walls Route object with its own information
        /// </summary>
        public readonly Route.Route BlindWallsRoute;

        /// <summary>
        /// Constructs an new FullRouteIO object
        /// </summary>
        public FullRouteIO()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads/creates the existing routes information 
        /// </summary>
        private void loadRoutes()
        {
            loadHistoricalKilometerRoute();
            loadBlindWallsRoute();
        }

        /// <summary>
        /// Loads/creates the Historical Kilometer Route, which can be retrieved as this class' attributes
        /// </summary>
        private void loadHistoricalKilometerRoute()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads/creates the Blind Walls Route, which can be retrieved as this class' attributes
        /// </summary>
        private void loadBlindWallsRoute()
        {
            throw new NotImplementedException();
        }

    }
}
