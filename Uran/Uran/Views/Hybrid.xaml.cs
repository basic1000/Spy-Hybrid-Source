using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel;
using Windows.UI.Popups;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Uran_Launcher.Classes;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace Uran_Launcher.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class Hybrid : Page
    {
        public Hybrid()
        {
            this.InitializeComponent();
            if(EndpointClient.hybrid == "false")
            {
                launchbtn.IsEnabled = false;
                launchbtn.Content = EndpointClient.hybridlabel;
            }
        }

        private async void launchbtn_Click(object sender, RoutedEventArgs e)
        {
           await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
        }
    }
}
