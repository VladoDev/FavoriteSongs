using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FavoriteSongs.Views
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        void Title_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            TitleLabel.IsVisible = !string.IsNullOrEmpty(TitleEntry.Text);
        }

        void Artist_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ArtistLabel.IsVisible = !string.IsNullOrEmpty(ArtistEntry.Text);
        }

        void Year_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            YearLabel.IsVisible = !string.IsNullOrEmpty(YearEntry.Text);
        }
    }
}

