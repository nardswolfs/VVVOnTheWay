using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VVVOnTheWay.Pages
{
    public sealed partial class PointDataPage : ContentDialog
    {
        private string[] _poiAudioPath;

        public PointDataPage(string[] poiTitle, string[] poiDescription, string poiImagePath, string[] poiAudioPath)
        {
            this.InitializeComponent();
            if (Settings.Language == VVVOnTheWay.Language.ENGLISH)
            {
                PointInfoText.Text = poiTitle[1] + "\n\n" + poiDescription[1];
            }
            else
            {
                PointInfoText.Text = poiTitle[2] + "\n\n" + poiDescription[2];
            }
            _poiAudioPath = poiAudioPath;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Language == VVVOnTheWay.Language.ENGLISH)
            {
                //play English audio
            }
            else
            {
                //play Dutch audio
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private async void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            var g = new GuidePage();
            await g.ShowAsync();
        }
    }
}
