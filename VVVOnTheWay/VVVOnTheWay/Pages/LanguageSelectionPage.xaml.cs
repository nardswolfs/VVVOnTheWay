﻿// Created by Bart Machielsen

#region

using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using VVVOnTheWay.Pages;

#endregion

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VVVOnTheWay
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LanguageSelectionPage : Page
    {
        private Route.Route route;

        public LanguageSelectionPage()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            LanguageSelectionFrame.Navigate(typeof(MapPage), route);
        }

        private async void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            var g = new GuidePage();
            await g.ShowAsync();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            route = e.Parameter as Route.Route;
        }

        private void SetColors()
        {
            if (Settings.Language == VVVOnTheWay.Language.ENGLISH)
            {
                EnglishButton.BorderBrush = new SolidColorBrush(Colors.Black);
                EnglishButton.BorderThickness = new Thickness(3);
                DutchButton.BorderBrush = new SolidColorBrush(Colors.Transparent);
                DutchButton.BorderThickness = new Thickness(1);
            }
            else
            {
                DutchButton.BorderBrush = new SolidColorBrush(Colors.Black);
                DutchButton.BorderThickness = new Thickness(3);
                EnglishButton.BorderBrush = new SolidColorBrush(Colors.Transparent);
                EnglishButton.BorderThickness = new Thickness(1);
            }
        }

        private void EnglishButton_Click(object sender, RoutedEventArgs e)
        {
            Settings.Language = VVVOnTheWay.Language.ENGLISH;
            SetColors();
        }

        private void DutchButton_Click(object sender, RoutedEventArgs e)
        {
            Settings.Language = VVVOnTheWay.Language.DUTCH;
            SetColors();
        }
    }
}