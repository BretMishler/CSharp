using System.Net;
using System.Threading;
using System.Windows;

namespace UnreliableWPFApplication
{
    public partial class MainWindow : Window
    {
        private int count = 1;
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();
        }
        
        // sets up eweb client, though new standard is httpclient
        private void RssButton_Click(object sender, RoutedEventArgs e)
        {
            var client = new WebClient();

            var data = client.DownloadString("http://www.filipekberg.se/rss/");

            // simulate slow network
            Thread.Sleep(10000);

            RssText.Text = data;
        }

        private void CounterButton_Click(object sender, RoutedEventArgs e)
        {
            CounterText.Text = $"Counter: {count++}";
        }
    }
}
