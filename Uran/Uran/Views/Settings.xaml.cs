using Windows.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.Core;
using System;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace Uran_Launcher.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
        }

        private void languageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string languageName = e.AddedItems[0].ToString();
            switch (languageName)
            {
                case "English":
                    ApplicationLanguages.PrimaryLanguageOverride = "en-US";
                    CoreApplication.RequestRestartAsync(string.Empty);
                    break;
                case "Deutsch":
                    ApplicationLanguages.PrimaryLanguageOverride = "de-DE";
                    CoreApplication.RequestRestartAsync(string.Empty);
                    break;
                case "Español":
                    ApplicationLanguages.PrimaryLanguageOverride = "es";
                    CoreApplication.RequestRestartAsync(string.Empty);
                    break;
                case "Русский":
                    ApplicationLanguages.PrimaryLanguageOverride = "ru";
                    CoreApplication.RequestRestartAsync(string.Empty);
                    break;
                case "Polski":
                    ApplicationLanguages.PrimaryLanguageOverride = "pl";
                    CoreApplication.RequestRestartAsync(string.Empty);
                    break;
                case "Türkçe":
                    ApplicationLanguages.PrimaryLanguageOverride = "tr";
                    CoreApplication.RequestRestartAsync(string.Empty);
                    break;
                case "Latinus":
                    ApplicationLanguages.PrimaryLanguageOverride = "la";
                    CoreApplication.RequestRestartAsync(string.Empty);
                    break;
                case "Français":
                    ApplicationLanguages.PrimaryLanguageOverride = "fr";
                    CoreApplication.RequestRestartAsync(string.Empty);
                    break;
            }

        }

        private void creditsbtn_Click(object sender, RoutedEventArgs e)
        {
            ToggleThemeTeachingTip1.IsOpen = true;
        }

        private void needhelpbtn_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("https://discord.gg/2akshAcHTQ");
            var success = Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private void verifyfnbtn_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("com.epicgames.launcher://apps/Fortnite?action=verify&silent=true");
            var success = Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private void SoundToggle_Toggled(object sender, RoutedEventArgs e)
        {
            if (SoundToggle.IsOn == true)
            {
                ElementSoundPlayer.State = ElementSoundPlayerState.On;
            }
            else
            {
                ElementSoundPlayer.State = ElementSoundPlayerState.Off;
                ElementSoundPlayer.SpatialAudioMode = ElementSpatialAudioMode.Off;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (ElementSoundPlayer.State == ElementSoundPlayerState.On)
                SoundToggle.IsOn = true;
        }
    }
}
