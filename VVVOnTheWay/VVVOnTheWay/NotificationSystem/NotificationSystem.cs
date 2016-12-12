using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Microsoft.Toolkit.Uwp.Notifications;

namespace VVVOnTheWay.NotificationSystem
{
    /// <summary>
    /// The function of this class is create tasks to send notifications to the device.
    /// </summary>
    static class NotificationSystem
    {
        /// <summary>
        /// Creates a task to send a push notification. In windows phone, this type of notification that is in the top bar of the screen is called
        /// a toast (yes, that is spelled correctly).
        /// </summary>
        /// <param name="notification"> A notification implementing the <see cref="INotification"/> interface.</param>
        /// <returns> A task to send a push notification. </returns>
        //TODO add a way to send the toastification
        public static async Task SenToastificationAsync(INotification notification)
        {
            if (notification.GetType() == typeof(Notification))
            {
                ToastNotification textToast = CreateTextToastNotification((Notification) notification);
                textToast.Tag = "textToast";
                ToastNotificationManager.CreateToastNotifier().Show(textToast);
            }
            else if (notification.GetType() == typeof(PoiNotification))
            {
                ToastNotification poiToast = CreatePoiToastNotification((PoiNotification) notification);
                poiToast.Tag = "poiToast";
                ToastNotificationManager.CreateToastNotifier().Show(poiToast);
            }
            else
            {
                throw new ArgumentException();
            }
        }
        

        /// <summary>
        /// Creates a task to send a sound notification.
        /// </summary>
        /// <returns> The task to send a sound notification. </returns>
        //TODO add a way to send the sound notifiction. This will probably become toasts with sound
        public static async Task SendSoundNotificationAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a task to send a sound notification.
        /// </summary>
        /// <returns> The task to send a vibration notification. </returns>
        //TODO add a way to send the vibration notifiction. THis doesn't have to be a seperate notification. We could just call the VibrationDevice.Vibrate
        public static async Task SendVibrationNotificationAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a task to send a push notification
        /// </summary>
        /// <param name="notification"> A notification implementing the <see cref="INotification"/> interface.</param>
        /// <returns> A task to send a pop up notification. </returns>
        public static async Task SendPopUpNotificationAsync(Notification notification)
        {
            var dialog = new MessageDialog(notification.Title, notification.Text);
            dialog.Commands.Add(new UICommand("Close", new UICommandInvokedHandler(CommandInvokedHandler)));
            dialog.ShowAsync();
        }

        /// <summary>
        /// A handler for all commands. See below for expansions to this text.
        /// </summary>
        /// <param name="c">the invoked command. For now must be something implementing teh IUICommand interface</param>
        private static void CommandInvokedHandler(IUICommand c)
        {
            //TODO see if we need a switch for this handler and then implement functions based on the button name
        }

        /// <summary>
        /// Creates a toast notification displaying text
        /// </summary>
        /// <param name="n">the notification that should be displayed</param>
        /// <returns> a toast notification based on the notification used in the parameter</returns>
        private static ToastNotification CreateTextToastNotification(Notification n)
        {
            #region Creating the toast details
            //TODO Under construction, don't know exactly what the launch does, but ill look into it
            ToastVisual visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = n.Title
                                },

                                new AdaptiveText()
                                {
                                    Text = n.Text
                                }
                            }
                }
            };

            ToastActionsCustom actions = new ToastActionsCustom()
            {
                Buttons =
                        {
                            new ToastButton("Close", "close")
                            {
                                ActivationType = ToastActivationType.Background
                            }
                        }
            };

            ToastContent content = new ToastContent()
            {
                Visual = visual,
                Actions = actions
            };
            #endregion

            //Putting the toast in the toaster
            var toast = new ToastNotification(content.GetXml());

            //Done toasting the toast
            return toast;
        }

        private static ToastNotification CreatePoiToastNotification(PoiNotification n)
        {
            #region Creating the toast details
            //TODO add toast audio, also, see todo above for the launch
            ToastVisual visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                            Text = n.Title
                        },

                        new AdaptiveText()
                        {
                            Text = n.Description
                        },

                        new AdaptiveImage()
                        {
                            Source = n.Image.UriSource.ToString()
                        }
                    }
                }
            };

            ToastContent content = new ToastContent()
            {
                Visual = visual
            };
            #endregion

            //Putting the toast in the toaster
            var toast = new ToastNotification(content.GetXml());

            //Done toasting the toast
            return toast;
        }
    }
}
