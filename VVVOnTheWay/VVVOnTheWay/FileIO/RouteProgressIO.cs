using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVVOnTheWay.FileIO
{
    /// <summary>
    /// Saves and loads the last route with user progress to and from a file
    /// </summary>
    class RouteProgressIO
    {
        /// <summary>
        /// The last saved-to-file Route object which contains user progress
        /// </summary>
        public readonly Route.Route LastSavedRoute;
        
        /// <summary>
        /// The filepath of the last saved route with user progresss
        /// </summary>
        private string lastSavedRouteFilePath { get; set; }

        /// <summary>
        /// Creates an instance of the RouteProgressIO class
        /// </summary>
        public RouteProgressIO()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves a route with user progress to a file
        /// </summary>
        /// <param name="routeInProgress">The Route object to save to a file</param>
        public void SaveRouteProgressToFile(Route.Route routeInProgress)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads the last saved route with user progress from a file, which can be retrieved via this class' attributes
        /// </summary>
        private void loadLastSavedRouteFromFile()
        {
            throw new NotImplementedException();
        }

    }
}
