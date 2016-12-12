using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace VVVOnTheWay.NotificationSystem
{
    /// <summary>
    /// A general implementation of the INotification interface, having only a text
    /// </summary>
    class Notification : INotification
    {
        /// <summary>
        /// Title: The property containing the tile for this notification
        /// Text: A property that contains thet text for notification, when applicable
        /// </summary>
        public string Title { get; }
        public string Text { get; }

        public Notification(string title, string text)
        {
            Title = title;
            Text = text;
        }
    }
}
