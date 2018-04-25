using System;
using System.Net;
using System.Threading;
using System.Windows;

namespace ReliableWPFApplication
{
    public partial class MainWindow : Window
    {
        private int count = 1;
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();
        }

        private void RssButton_Click(object sender, RoutedEventArgs e)
        {
            var client = new WebClient();

            // sync call that blocks application
            //var data = client.DownloadString("http://www.filipekberg.se/rss/");

            // use event based async patter
            // once string is downloaded, web client will notify us by raising an event
            client.DownloadStringAsync(new Uri("http://www.filipekberg.se/rss/"));

            client.DownloadStringCompleted += Client_DownloadStringCompleted;
        }

        private void Client_DownloadStringCompleted(object sender, 
            DownloadStringCompletedEventArgs e)
        {
            // sets the rss text to the result we got from the asynch operation
            RssText.Text = e.Result;

            BusyIndicator.Visibility = Visibility.Hidden;

            RssButton.IsEnabled = true;
        }

        private void CounterButton_Click(object sender, RoutedEventArgs e)
        {
            CounterText.Text = $"Counter: {count++}";
        }
    }
}
