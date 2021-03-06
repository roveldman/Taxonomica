﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Taxonomica
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            contentFrame.IsNavigationStackEnabled = true;
            contentFrame.Navigate(typeof(TaxonPage));

            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            currentView.BackRequested += MainWindowBackRequested;
        }

        private void MainWindowBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (contentFrame.CanGoBack)
            {
                contentFrame.GoBack();
            }
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var itemContent = args.InvokedItem as TextBlock;
            if (itemContent != null)
            {
                switch (itemContent.Tag)
                {
                    case "hierarchy":
                        contentFrame.Navigate(typeof(TaxonPage));
                        break;
                    case "search":
                        contentFrame.Navigate(typeof(SearchPage));
                        break;
                    case "explore":
                        contentFrame.Navigate(typeof(ExplorePage));
                        break;
                    case "about":
                        contentFrame.Navigate(typeof(AboutPage));
                        break;
                }
            }
        }
    }
}
