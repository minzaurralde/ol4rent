
using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace BingPrueba
{
    public partial class ChhoseMyPosition : PhoneApplicationPage
    {
        public ChhoseMyPosition()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //set position button
            double longitude;
            double latitude;
            try
            {
                longitude = double.Parse(longitudeTB.Text.ToString());
                latitude = double.Parse(LatitudeTB.Text.ToString());
                SharedInformation.myLongitude = longitude;
                SharedInformation.myLatitude = latitude;

                MessageBox.Show("Your location was successfully set!");
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            catch (Exception exc)
            {
                MessageBox.Show("Please enter a valid location!" + exc.Message);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //cancel button
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}