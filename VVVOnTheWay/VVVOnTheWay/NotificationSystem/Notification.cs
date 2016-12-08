using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVVOnTheWay.NotificationSystem
{
    /// <summary>
    /// A general implementation of the INotification interface, having only a text
    /// </summary>
    class Notification : INotification
    {
        private string Text { get; set; }

        /// <summary>
        /// Constructor for a notification object.
        /// </summary>
        ///TODO Add body if need be
        public Notification()
        {
            
        }
    }
}
