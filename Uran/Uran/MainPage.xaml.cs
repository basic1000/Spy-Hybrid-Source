using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace Uran
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(740, 400);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(740, 400));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void nvSample_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                ContentViewer.Navigate(typeof(Uran_Launcher.Views.Settings));
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;
                if (args.SelectedItem == Hybrid)
                {
                    ContentViewer.Navigate(typeof(Uran_Launcher.Views.Hybrid));
                }
                else if (args.SelectedItem == Private)
                {
                    ContentViewer.Navigate(typeof(Uran_Launcher.Views.Private));
                }
            }
        }

        private void nvSample_Loaded(object sender, RoutedEventArgs e)
        {
            ContentViewer.Navigate(typeof(Uran_Launcher.Views.Hybrid));
            ApplicationView appView = ApplicationView.GetForCurrentView();
        }
    }
}
