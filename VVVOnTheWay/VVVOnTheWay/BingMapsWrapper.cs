using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;


namespace LocationSystem
{
    class BingMapsWrapper
    {
        
        ///<summary>
        ///get current location of the user
        ///</summary>
        ///TODO: Return Geoposition
       public Geoposition getCurrentPosition()
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///get target location 
        ///caculate distance to target location
        /// </summary>
        /// TODO: Return double
       public double getDistanceTo(Geoposition target)
        {
            throw new NotImplementedException();
        }

    }
}
